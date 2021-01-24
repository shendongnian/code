	public static class MainClass
	{
	    public static Dictionary<string, Dictionary<string, long>> Dictionaries = new Dictionary<string, Dictionary<string, long>>() {
	        { "SubDictionary", new Dictionary<string, long>()
	            {
	                { "property1", 365635},
	                { "property2", 156346},
	                { "property3", 280847},
	            }
	        },
	        { "SubDictionary2", new Dictionary<string, long>()
	            {
	                { "property4", 36351526  },
	                { "property5", 152415    },
	                { "property6", 280114157 },
	            }
	        }
	    };
		
		public static bool FindProperty(string subDictionaryName, IEnumerable<long> list)
	    {
			Dictionary<string, long> dict;
	        Dictionaries.TryGetValue(subDictionaryName, out dict);
			if (dict == null)
			{
				return false;
			}
			
			if (list.Any(i => dict.ContainsValue(i)))
			{
				return true;
			}
			else
			{
				return false;
			}
	    }
	}
