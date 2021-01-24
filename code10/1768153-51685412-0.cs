    using UnityEngine;
    using System.Collections.Generic;
    using UnityEngine.UI;
    public class FrameSelector : MonoBehaviour
    {
       List<bool> frame; //make list field not local variable to reuse
       System.Random rand;
       void Start()
       {
            rand = new System.Rand();
            frame = new List<bool>();
            frame.Add(GameObject.Find("Frame1").GetComponent<Image>().enabled = true);
            frame.Add(GameObject.Find("Frame2").GetComponent<Image>().enabled = true);
            frame.Add(GameObject.Find("Frame3").GetComponent<Image>().enabled = true);
            frame.Add(GameObject.Find("Frame4").GetComponent<Image>().enabled = true);    
        }
      void GetRandomObject() // call on click making it public and assigning in inspector 
      {
         int randomNumber = rnd.Next(0,frame.Length-1); //length-1 for not throwing 
    //indexError
         //do what you want with your randomNumber
      }
