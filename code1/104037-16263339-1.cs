    using UnityEngine;
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    
    public class DllTeste : MonoBehaviour
    {
    	public int x;
    	[DllImport ("PS_Cam.dll", EntryPoint="CamStart", CallingConvention = CallingConvention.StdCall)]
    	private static extern IntPtr CamStart (int s);//i can put <string> in same place of <int>
    	
    	
    	void Start ()
    	{
    		
    	}
    
    	void Update ()
    	{
    //		IntPtr a =  CamStart(x);
    //		string b = Marshal.PtrToStringAnsi(a);	
    //		Debug.Log(b);
    		Debug.Log(Marshal.PtrToStringAnsi(CamStart(x)));
    	}
    }
