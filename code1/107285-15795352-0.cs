        //this is the best in C#
        
        //bool contains(array,subarray)
        //  when find (subarray[0])
        //      while subarray[next] IS OK
        //          subarray.end then Return True
        public static bool ContainSubArray<T>(T[] findIn, out int found_index,
     params T[]toFind)
        {
        	found_index = -1;
        	if (toFind.Length < findIn.Length)
        	{
        	  
        		int index = 0;
        		Func<int, bool> NextOk = (i) =>
        			{
        				if(index < findIn.Length)
        					return findIn[++index].Equals(toFind[i]);
        				return false;
        			};
        		//----------
        		int n=1;
        		for (; index < findIn.Length; index++)
        		{
        			if (findIn[index].Equals(toFind[0]))
        			{
        				found_index=index;
        				while (n < toFind.Length && NextOk(n))
        					n++;
        			}
        			if (n == toFind.Length)
        			{
        				return true;
        			}
        		}
        		
        	}
        	return false;
        }
