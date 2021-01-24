    public class CustomComparer : IComparer<string>
    {
        int IComparer<string>.Compare(string x, string y)
        {
            var items1 = x.ToCharArray();
    		var items2 = y.ToCharArray();
    		var temp = items1.Zip(items2,(a,b)=> new{Item1 = a, Item2=b});
    		var difference = temp.FirstOrDefault(item=>item.Item1!=item.Item2);
    		
    		if(difference!=null)
    		{
    			if(difference.Item1=='.' && difference.Item2=='+')
    				return 1;
    			if(difference.Item1=='+' && difference.Item2=='.')
    				return -1;
    		}
    		return string.Compare(x,y);
        }
    
        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
