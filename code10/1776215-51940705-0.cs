    class Program
    {
    	static MemberData[] memarray1 = new MemberData[10000];
    	static MemberData[] memarray2 = new MemberData[10000];
    	static void Main(string[] args)
    	{
    		for (int i = 0; i < memarray1.Length; i++)
    		{
    			memarray1[i] = new MemberData(i + 1, "MemName" + i + 1, true);
    			memarray2[i] = new MemberData(i + 1, "MemName" + i + 1, true);
    		}
    
    		// SIMULATING YOUR APP OPERATION OF CHANGING A RANDOM ARRAY VALUE IN memarray1
    
    		int tempIndex = new Random().Next(0, 9999);
    
    		memarray1[tempIndex].meme_name = "ChangedName";
    		memarray1[tempIndex].meme_active = false;
    
    		//FOR YOUR UDERSTADNING TAKING meme_ck IN AN INTEGER VARIABLE
    
    		int ck_in_mem1 = memarray1[tempIndex].meme_ck;
    
    		//FINDING ITEM IN ARRAY2
    
    		MemberData tempData = memarray2.Where(val => val.meme_ck == ck_in_mem1).FirstOrDefault();
    
    		// THIS IS YOUR ITEM.
    
    		Console.ReadLine();
    	}
    }
