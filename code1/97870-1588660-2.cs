    class MySubSet    
    {        
        int subsetID;        
        List<int> subset = new List<int>();        
        public List<int> SubSet 
        {            
            get { return subset; }             
            set { subset = value; }        
        }        
        public void Add(int i) { subset.Add(i); }  // pass through to subset.Add()
     }
