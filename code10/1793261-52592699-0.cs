    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class spawner : MonoBehaviour 
    {
    
        public Transform spawnPos;
        public GameObject spawnee;
        GameObject obj;
        GameObject objt;    
    
        // You need an additional variable for the Object you instantiate
        GameObject lastInstantiatedObject;
        private void Update () {        
    
            // use GetKeyDown to fire only once per click
            if((Input.GetKeyDown (KeyCode.G))) 
            {
                // store a reference to the instaiated object so you can access it later
                lastInstantiatedObject = Instantiate(spawnee, spawnPos.position, spawnPos.rotation);
            }       
        }
    
        privte void FixedUpdate () 
        {
            if((Input.GetKey (KeyCode.H))) 
            {
                obj = GameObject.Find ("Seeker(Clone)");
                obj.GetComponent<Unit> ().Speed =20;
                // Target is of type Transform
                // Usually to get a component you would have to call
                // lastInstantiatedObject.GetComponent<TypeOfComponent>()
                // but Trasnform is an exception. Since every GameObject has a Transform
                // component, you can use the shortcut lastInstantiatedObject.transform
                obj.GetComponent<Unit> ().Target = lastInstantiatedObject.transform;
                Debug.Log (obj.GetComponent<Unit> ().Target  );
            }
        }   
    }
