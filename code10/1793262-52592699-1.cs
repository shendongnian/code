    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class spawner : MonoBehaviour 
    {
    
        public Transform spawnPos;
        public GameObject spawnee;
        private GameObject obj;
        // private GameObject objt;    
    
        // here we store and re-use the Unit component reference
        Unit unit;
        // You need an additional variable for the Object you instantiate
        GameObject lastInstantiatedObject;
        private void Awake()
        {
            // do those expensive methods already and only once in the beginning
            obj = GameObject.Find ("Seeker(Clone)");
            unit = obj.GetComponent<Unit>();
        }
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
            if((Input.GetKeyDown (KeyCode.H))) 
            {
                // unit was set already in Awake so we can reuse the reference
                // anyway just in case the object was not there yet while Awake
                // add a little check
                if(!unit)
                {
                    Awake();
                }
                // if unit is still not set you have an error and should not go ahead
                if(!unit)
                {
                    Debug.LogError("For some reason unit could not be set!", this);
                    return;
                }
                unit.Speed =20;
                // Before going on you should add a similar check for the lastInstantiatedObject variable
                if(!lastInstantiatedObject)
                {
                    Debug.LogError("No object instanitated so far or it was destroyed again!", this);
                    return;
                }
                // Target is of type Transform
                // Usually to get a component you would have to call
                // lastInstantiatedObject.GetComponent<TypeOfComponent>()
                // but Trasnform is an exception. Since every GameObject has a Transform
                // component, you can use the shortcut lastInstantiatedObject.transform
                unit.Target = lastInstantiatedObject.transform;
                Debug.Log (unit.Target);
            }
        }   
    }
