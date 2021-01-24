        private static List<string> userList = new List<string>(File.ReadAllLines(@"C:\Users\Erik\Desktop\InfernoUser-workspace-db.txt"));
        private static HashSet<string> enterpriseUserList = new HashSet<string>(File.ReadAllLines(@"C:\Users\Erik\Desktop\InfernoEnterpriseUser-local-db.txt"));
    
     [MethodImpl(MethodImplOptions.AggressiveInlining)]
       private static void CheckAddress(int id,string username)
    {                      
        var userid = ToAddress(username);
        if (enterpriseUserList.Contains(userid))
        {
           // todo
        }            
    }
    
    
    private static void Parallel() 
    {
        var ranges = Partitioner.Create(0,userList.Count);
        Parallel.ForEach(ranges ,(range)=>{
         for(int i=range.Item1;i<range.Item2;i++){
                  CheckAddress(i,userList[i])               
         }}
    
    }
