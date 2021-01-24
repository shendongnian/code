    void bools2actions(bool[] bb, Action[] actions)
    {
    	var i = bools2int(bb);
    	actions[i]();
    }
				
    void demo()
    {
    	bools2actions(new bool[]{true, true},
    	      new Action[]
    	      {
    		      ()=>Console.WriteLine(0),
    		      ()=>Console.WriteLine(1),
    		      ()=>Console.WriteLine(2),
    		      ()=>Console.WriteLine(3),
    	      }
    	     );
    }
