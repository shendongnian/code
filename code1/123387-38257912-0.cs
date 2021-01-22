    //Your models
        public class Dto1
        {
            public int id { get; set; }
            public string Property2 { get; set; }
            public string Property3 { get; set; }
            public string Property4 { get; set; }
            public string Property5 { get; set; }
        
            public virtual Dto2 dto2{ get; set; }
        
        }
        
        public class Dto2
        {
            public int id { get; set; }
            public string PropertyB { get; set; }
            public string PropertyC { get; set; }
            public string PropertyD { get; set; }
            public string PropertyE { get; set; }
        }
        
        
    //Your ViewModels
        public class Dto1ViewModel
        {
            public string Property1 { get; set; }
            public string Property2 { get; set; }
        
            public virtual Dto2VMForDto1 dto2{ get; set; }
        }
        
    //Special ViewModel just for sliding into the above
        public class Dto2VMForDto1 
        {
            public int id { get; set; }
            public string PropertyB { get; set; }
            public string PropertyC { get; set; }
        }
