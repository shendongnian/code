      public List<Model> ListDaftarPjsp()
        {
            List<Model> list = from x in db.PJSPEvaluation
                                      select new Model
                                      {
                                          foo = x.Foo,
                                          bar = x.Bar               
                                      };
    
            foreach (Model item in list) 
            {
                item.condition = "example";
            }
            return list;
        }
        
        public class Model{
            public string foo{ get; set; }
            public string bar { get; set; }
            public string condition{ get; set; }
        }
