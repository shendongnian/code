    Properties
    {
    	_Timer("Timer",Float) = 0
    }
    
    float WaveTime = sin(_Timer);
_____
    using System.Collections;
    using UnityEngine;
    
    public class Circle : MonoBehaviour {
    	public float _timeElapsed;
    	
    
    	void OnEnable(){
    		_timeElapsed = 0;
    	}
    
    public void Update() {
        _timeElapsed += Time.deltaTime;
    	var _renderer = GetComponent<MeshRenderer>();
        _renderer.material.SetFloat("_Timer", _timeElapsed);
    }
    }
