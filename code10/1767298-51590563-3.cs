    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    public class sdfsd : MonoBehaviour {
        // Use this for initialization
        void Start () {
            StartCoroutine(WaitUntilAPressed());
        }
        IEnumerator WaitUntilAPressed()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            yield return new WaitUntil(()=> Input.GetKeyDown(KeyCode.A));
    
            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
    
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Debug.Log(elapsedTime);
        }
    }
