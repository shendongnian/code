    using System.Collections.Generic;
    using System.Linq; 
    using System.Linq.Dynamic;
         static void Main(string[] args)
            {
                List<data> ListOfdata = new List<data>();
                for (int i = 1; i < 10; i++)
                {
                    data newdata = new data();
                    newdata.column1 = i;
                    newdata.column2 = i + 1;
                    ListOfdata.Add(newdata);
                }
    
                //below I update the boolean condition, it needs double == for comparison  
                // so column1 == column2-1 will be evaluated correctly
                string condition1 = "column1!=Null AND column1==column2-1";
    
                //used 'condition1' instead of 'condition'
                var filter = ListOfdata.Where(condition1).ToList();
    
                // HERE filter.Count() give me 9 !!
            }
        public class data
        {
            public int column1 { get; set; }
            public int column2 { get; set; }
            public string column3 { get; set; }
        }
