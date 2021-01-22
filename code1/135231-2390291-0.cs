    Public class MyClassB : MyClassA
    {
     public String Property_Z { get; set; }
    
     public static explicit operator MyClassB(MyClassA a)
     {
	Property_A = a.Property_A;
	/* ... */
	Property_Y = a.Property_Y;
     }
    }
