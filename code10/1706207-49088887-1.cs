    namespace testproject
    {
        public class TestClass
        {
    		string name;
    		public string Name
    		{
    			get {return name;}
    			set {name = value;}
    		}
    		int[] integers;
    		public int this[int i]
    		{
    			get {if (i < 5) {return integers[i];} else {return -1;}}
    			set {if (i < 5) {integers[i] = value;}}
    		}
    		public TestClass(string _name)
    		{
    			name = _name;
                integers = new int[100];
    		}
    		public override string ToString ()
    		{
    			string output = name + ":";
    			for (int i = 0; i < 5; i++)
    			{
    				if (i != 4) {output += " " + i.ToString() + ",";}
    				else {output += " " + i.ToString();}
    			}
    			return output;
    		}
            
        }
    }
