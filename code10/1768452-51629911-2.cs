            var strings = new List<string>() { "012abc", "120ccc", "000aaa" };
    		var arrays = strings.Select(x => x.ToCharArray());   		
    		
    		var charResult = arrays.Aggregate((a, b) => b.ToList().Select((t,i) => (char)Math.Max(t, a[i])).ToArray());   		
    		
    		Console.Write(new string(charResult.ToArray()));
