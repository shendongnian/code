    using System;
    using UnityEngine;
    
    [CreateAssetMenu(menuName = "Dog", fileName = "New Dog")]
    public class Dog : ScriptableObject {
    	public GameObject Go;
    	public static event Action<string> ScriptableToGameobjectEvent;
    
    	private void Awake() {
    		EventScript.GameobjectToScriptableEvent += InstanceCreated;		
    		if (Application.isPlaying) {
    			ScriptableToGameobjectEvent("Dog Created");
    		}
    	}
    
    	private void InstanceCreated(GameObject go) {
    		Go = go;
    		Debug.Log(Go.name);
    	}
    }
