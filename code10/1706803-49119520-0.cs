    // A more modest marshalling example:
    // C# code
        
            
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Runtime.InteropServices;
        
        namespace ConsoleApplication1
        {
        
            [StructLayout(LayoutKind.Sequential)]
            public struct input_struct
            {
                public int a;
                public int b;
                public int c;
            }
        
            [StructLayout(LayoutKind.Sequential)]
            public struct output_struct
            {
                [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
                public int[] o;
            }
        
            public class NativeVector
            {
                [DllImport("NativeVector.dll")]
                public static extern int RunDll(input_struct i, ref output_struct o);
            }
        
            class Program
            {
               static output_struct output = new output_struct();
        
                static void Main(string[] args)
                {
                    input_struct input;
                    input.a = 1;
                    input.b = 2;
                    input.c = 3;
                    output.o = new int[3];
                    NativeVector.RunDll(input, ref output);
                }
            }
        }
        
            
        // C++ code
        
        #include "stdafx.h"
        #include <vector>
        
        struct input
        {
        	int a;
        	int b;
        	int c;
        };
        
        struct output
        {
        	int v[3];
        };
        
        extern "C" 
        {
        	__declspec(dllexport) int _stdcall  RunDll(struct input i, struct output& o)
        	{
        		o.v[0] = i.a;
        		o.v[1] = i.b;
        		o.v[2] = i.c;
        		return 0;
        	}
        }
