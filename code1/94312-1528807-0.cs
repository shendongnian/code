    public class Class1
    {
        private String categoryIDList = "1,2,3";
        public Class1()
        {
            List<Int32> categoryList = new List<Int32>();
            String[] categoryIDs = categoryIDList.Split(",");
            
            foreach(String category in categoryIDs)
                categoryList.Add(Int32.Parse( category));
        
        }
    }
