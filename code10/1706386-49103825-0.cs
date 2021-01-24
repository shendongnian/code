    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using LitJson; // You can use something else if you like, idea is to save the List in string format.
    
    public class KeyStrokeRecorder : MonoBehaviour {
    
    	public class KeyStroke {
            public enum KeyState {
			    Idle,
			    Pressed,
			    Released,
		    }
    		public KeyCode keycode;	
            public string time;
            public KeyState state;     		
    	}    	
    
    	public List<KeyStroke> mKeyStrokes;
        public RecorderState recorderState = RecorderState.Idle;
    	public static KeyStrokeRecorder instance;
    
    	void Awake(){
    		instance = this;	
    	}
    
    	void Start () {
    		
    	}
    
    	public float gameTime = 0;
    	void Update () {    
    		if( isRecording || isPlayback)
    			gameTime += Time.deltaTime;
    
    		if( Input.GetKeyUp(KeyCode.Space) )
    		{
    			saveKeystrokes();
    		}
    	}
    
    	void saveKeystrokes()
    	{
    		string json = JsonMapper.ToJson(mKeyStrokes);
    		PlayerPrefs.SetString("KeyStrokes", json);
    	}
    
    	void loadKeystrokes()
    	{
    		string json = PlayerPrefs.GetString("KeyStrokes");	
    		if( !string.IsNullOrEmpty(json) )
    			mKeyStrokes = JsonMapper.ToObject<List<KeyStroke>>(json);
    		else
    			mKeyStrokes = new List<KeyStroke>();    
    	}
    
    	public void Initialize() {
    		gameTime = 0;
    		isRecording = false;
     		isPlayback = false;
    
     		loadKeystrokes();
    
    		if( mKeyStrokes.Count > 0 )
    		{
    			recorderState = RecorderState.Playback;
    		}
    		else
    		{
    			recorderState = RecorderState.Recording;
    		}    			
    	}
    
    	bool isRecording = false;
    	public void Run() {
    		if( recorderState == RecorderState.Recording )
    			isRecording = true;
    		else if( recorderState == RecorderState.Playback )
    			isPlayback = true;
    	} 
    
    	public void Stop() {
    		if( recorderState == RecorderState.Recording )
    			isRecording = false;
    		else if( recorderState == RecorderState.Playback )
    			isPlayback = false;
    	} 
    
    	bool isPlayback = false;
     	public bool GetKey(KeyCode keycode)
    	{ 
    		if( isPlayback )
    		{
    			for(int i=0; i<mKeyStrokes.Count; i++)
    			{
    				float tTime;
    				float.TryParse(mKeyStrokes[i].time, out tTime);
    					
    				if( mKeyStrokes[i].keyname == keycode.ToString() )
    				{
    					if( gameTime > tTime-0.5f && gameTime < tTime+0.5f )
    					{
    						if( mKeyStrokes[i].state == KeyStroke.State.Pressed)
    							return true;
    						else
    							return false;
    					} 
    				} 
    			}    
    			return false;
    		}
    		else if( isRecording )
    		{
                KeyStroke keystroke = new KeyStroke();
    			keystroke.keyname = keycode.ToString();
    			keystroke.time = gameTime.ToString();
    			if( Input.GetKeyDown(keycode) )
    			{   				
     				keystroke.state = KeyStroke.State.Pressed;    
    				mKeyStrokes.Add(keystroke);    				
    			}
    			else if( Input.GetKeyUp(keycode) )
    			{   				
    				keystroke.state = KeyStroke.State.Released;	    
    				mKeyStrokes.Add(keystroke);
    			}
    		}    
    		return Input.GetKey(keycode);
    	}
    }
