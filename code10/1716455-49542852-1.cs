    using UnityEngine;
    using System;
    public class EventScript : MonoBehaviour {
    
    	public static event Action<GameObject> GameobjectToScriptableEvent;
    	public ScriptableObject myScriptable;
    
    	private void Awake() {
    		Dog.ScriptableToGameobjectEvent += DogCreated;
    	}
    
    	private void Start() {		
    		myScriptable = ScriptableObject.CreateInstance<Dog>();
    	}
    
    	private void DogCreated(string str) {
    		Debug.Log(str);
    		GameobjectToScriptableEvent(gameObject);
    	}
    }
