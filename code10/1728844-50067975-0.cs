    using System.ComponentModel.DataAnnotations;
    namespace YourNameSpace
    {
        public abstract class ManagedRecord
        {
            [ScaffoldColumn(false)]
            public DateTime CreatedDate{ get; set; }
    
            [ScaffoldColumn(false)]
            public bool Deleted { get; set; }
        }
    }
