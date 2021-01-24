public void SignInWithEmail() {
    // auth.SignInWithEmailAndPasswordAsyn() is run on the local thread, 
    // ...so no issues here
    auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
      
     // .ContinueWith() is an asynchronous call 
     // ...to the lambda function defined within the  task=> { }
     // and most importantly, it will be run on a different thread, hence the issue
      DatabaseReference.GetValueAsync().ContinueWith(task => {
    
        //HERE IS THE PROBLEM 
        userPanel.SetActive(true);
        authPanel.SetActive(false);
    }
  }
}
 5. **Suggested Solution:**
For those calls which require callback functions, like...
>     DatabaseReference.GetValueAsync()
...you can...
 - send them to a function which is set up to run on that initial thread.
 - ...and which uses a queue to ensure that they will be run in the order that they were added.
 - ...and using the singleton pattern, in the way advised by the Unity team.
Actual solution
---------------
 1. Place the code below into your scene on a gameObject that will always be enabled, so that you have a worker that... 
 - always runs on the local thread
 - can be sent those callback functions to be run on the local thread.
<!-- language: c# --> 
using System;
using System.Collections.Generic;
using UnityEngine;
internal class UnityMainThread : MonoBehaviour
{
    internal static UnityMainThread wkr;
    Queue<Action> jobs = new Queue<Action>();
    
    void Awake() {
        wkr = this;
    }
    
    void Update() {
        while (jobs.Count > 0) 
            jobs.Dequeue().Invoke();
    }
    
    internal void AddJob(Action newJob) {
        jobs.Enqueue(newJob);
    }
}
 2. Now from your code, you can simply call...
    >      UnityMainThread.wkr.AddJob();
...so that your code remains easy to read (and manage), as shown below...
 
<!-- language: c# --> 
public void SignInWithEmail() {
    auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
      
      DatabaseReference.GetValueAsync().ContinueWith(task => {
        UnityMainThread.wkr.AddJob(() => {
            // Will run on main thread, hence issue is solved
            userPanel.SetActive(true);
            authPanel.SetActive(false);            
        })
    }
  }
}
