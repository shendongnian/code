    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using UnityEngine;
    	
    public class TestStructWithFixed : MonoBehaviour
    {
    	public const int MAX = 5;
    	public const int SIZEOF_ELEMENT = 8;
    	
    	public struct Element
    	{
    		public uint x;
    		public uint y;
    		//8 bytes
    	}
    	
    	[StructLayout(LayoutKind.Sequential, Pack = 1)]
    	public unsafe struct Container
    	{
    		public int id; //4 bytes
    		public unsafe fixed byte bytes[MAX * SIZEOF_ELEMENT];
    	}
    	
    	public Container container;
    	
    	void Start ()
    	{
    		Debug.Log("SizeOf container="+Marshal.SizeOf(container));
    		Debug.Log("SizeOf element  ="+Marshal.SizeOf(new Element()));
    		
    		unsafe
    		{
    			Element* elements;
    			fixed (byte* cptr = container.bytes)
    			{
    				elements = (Element*) cptr;
    				
    				for (int i = 0; i < MAX; i++)
    					Debug.Log("i="+i+":"+elements[i].x);
    				
    				//low order bytes of Element.x are at 0, 8, 16, 24, 32 respectively for the 5 Elements
    				cptr[0] = 4;
    				cptr[32] = 7;
    				
    				for (int i = 0; i < MAX; i++)
    					Debug.Log("i="+i+":"+elements[i].x); //shows 4 and 7 at [0] and [4] respectively.
    			}
    
    		}
    	}
    }
