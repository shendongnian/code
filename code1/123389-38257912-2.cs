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
