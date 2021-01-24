    using System;
    using System.Collections.Generic;
    using System.Linq;
					
    public class Program
    {
	    private static void LoadGameData(String input) {
		    // Do something inside your input here.
	    }
        public static void Main() {
          Start();
        }
	
	    public static void Start()
	    {
		    string snapshotJson = "Sample data";
		
		    // Same Class Call
		    LoadGameData(snapshotJson);
		
		    // Other Class Call
		    var otherClassInstance = new TestClass();
		
		    otherClassInstance.LoadGameData(snapshotJson);
	    }
    }
    public class TestClass {
        public void LoadGameData(String input) {
		    // Do something inside your input here.
	    }
    }
