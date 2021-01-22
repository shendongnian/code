    public class MultiIndexer : List<string>  
    {
        public string this[int i]
        {
            get{
                return this[i];
            }
        }
        public string this[string pValue]
        {
            get
            {
                //Just to demonstrate
                return this.Find(x => x == pValue);  
            }
        }      
    }
