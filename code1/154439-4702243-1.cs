    class Thing 
    {
       public int  Id {get;set;}
       public string Text{get;set;}
    }
    
    void Main()
    {
    	var t1 = new Thing{ Id = 3, Text = "hi" };
    	var t2 = new Thing{ Id = 3, Text = "hi" };
    	var t3 = new Thing{ Id = 4, Text = "bye" };
    	
    	Console.WriteLine(DoObjectsMatch(t1,t2)); // True
    	Console.WriteLine(DoObjectsMatch(t2,t3)); // False
    }
