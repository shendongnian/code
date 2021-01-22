    using System;
    
    internal class Pointer {
    	public unsafe void Main() {
    		int ptr1 = 0;
    		int* ptr2 = &ptr1;
    		*ptr2 = 220;
    
    		Console.WriteLine(ptr1);
    	}
    }
