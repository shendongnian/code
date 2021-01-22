    public class MyData : ISomeData
    {
    
        IEnumerable<string> ISomeData.Data
        {
            get
            {
                  return _myData;
            }
        }
    
        public List<string> Data
        {
              get
              {
                 return (List<string>)((ISomeData)this).Data;
              }
        }
    
    }
