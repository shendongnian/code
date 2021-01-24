    using UnityEngine;
     using System.Collections;
      
     public class SameYCoordinateAsOther : MonoBehaviour {
      
         Transform otherTransform;
      
         void Start() {
            // you can set a reference to the "parent" cube
            otherTransform = GameObject.Find("cube1").transform;
         }
      
         void Update() {
            // here we force the position of the current object to have the same y as the parent
            transform.position = new Vector3(transform.position.x, reference.position.y, transform.position.z);
         }
    }
