    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    
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
    
    	float gameTime = 0;    
    	bool isRecording = false;    	
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
