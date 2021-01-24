    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class MyClass : MonoBehaviour
    {
    	// This is basic a singleton implementation
    	static MyClass sharedInstance = null;
    	public static MyClass GetInstance()
    	{
    		if(sharedInstance == null)
    		{
    			// Create a "MyClassSingleton" gameObject if for the first time
    			GameObject g = new GameObject("MyClassSingleton");
    			// Attach "MyClass" component and set our instance
    			sharedInstance = g.AddComponent<MyClass>();
    		}
    		return sharedInstance;
    	}
    	
    	[SerializeField]
    	GameObject myGameObjectPrefab;
    
    	List<GameObject> myGameObjectList;
    
    	void Awake()
    	{
    		// Intialize our list
    		myGameObjectList = new List<GameObject>();
    	}
    
    	public void SpawnGameObject(Vector3 position)
    	{ 
    		// Instantiate the gameObject
    		GameObject g = GameObject.Instantiate(myGameObjectPrefab);
    		// Set the position of the gameObject
    		g.transform.position = position;
    		// Add the instantiated gameObject to our list
    		myGameObjectList.Add(g);
    	}
    
    	public List<GameObject> GetGameObjectList()
    	{
    		return myGameObjectList;
    	}
    
    	void Update()
    	{
    		// For spawning the game objects
    		if(Input.GetKeyDown(KeyCode.Alpha1))
    		{
    			SpawnGameObject(Vector3.zero);
    		}
    
    		if(Input.GetKeyDown(KeyCode.Alpha2))
    		{
    			List<GameObject> list = GetGameObjectList();
    			if(list != null)
    			{
    				Debug.Log("COUNT: " + list.Count);
    			}
    		}
    	}
    }
