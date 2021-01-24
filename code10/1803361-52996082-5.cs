    public static Dto ToDto2((string, int) source, string[] nameMapping)
    		{
    			var dic = new Dictionary<string, object> {{nameMapping[0], source.Item1}, {nameMapping[1], source.Item2}};
    			return new Dto {Foo = (string)dic[nameMapping[0]], Bar = (int)dic[nameMapping[1]]};
    		}
    
