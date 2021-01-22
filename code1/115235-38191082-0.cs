    private static IEnumerable<string> FindPermutations(string set)
    		{
    			var output = new List<string>();
    			switch (set.Length)
    			{
    				case 1:
    					output.Add(set);
    					break;
    				default:
    					output.AddRange(from c in set let tail = set.Remove(set.IndexOf(c), 1) from tailPerms in FindPermutations(tail) select c + tailPerms);
    					break;
    			}
    			return output;
    		}
