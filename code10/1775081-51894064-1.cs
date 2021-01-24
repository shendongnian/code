        public static void Main()
        	{
        		string[] input = new string[]
                            { "Parent1:Child1", "Parent1:Child2",
                              "Parent1:Child3", "Parent1:Child4", 
                              "Parent2:Child1", "Parent2:Child2", 
                              "Parent2:Child3", "Parent2:Child4", 
                              "Parent3:Child1","Parent3:Child2"
                            };
        		
        		Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        		foreach(string s1 in input)
        		{
        			string[] splitted = s1.Split(':');
        			List<string> temp = new List<string>();
        			if(!dict.ContainsKey(splitted[0]))
        			{
        				temp.Add(splitted[1]);
        				dict.Add(splitted[0], temp);
        			}
        			else
        				dict[splitted[0]].Add(splitted[1]);
        		}
    
        		foreach(KeyValuePair<string, List<string>> kv in dict){
        			Console.WriteLine(kv.Key+" : "+ string.Join(",",kv.Value));
        		}    		
        	}
