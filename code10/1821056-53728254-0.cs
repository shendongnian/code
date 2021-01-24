        public class MainEntity
        {
            public int Id { get; set; }
            ICollection<MiddleEntity> MiddleEntities { get; set; }
            //Other properties...
        }
        public class MiddleEntity
        {
            public int Id { get; set; }
    
            public int MainEntityId { get; set; }
            public MainEntity MainEntity { get; set; }
    
            ICollection<InnerEntity> InnerEntities { get; set; }
            //Other properties...
        }
        public class InnerEntity
        {
            public int Id { get; set; }
            public int MiddleEntityId { get; set; }
            public MiddleEntity MiddleEntity { get; set; }
            //Other properties...
        }
