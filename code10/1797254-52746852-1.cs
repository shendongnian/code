    using System;
    using System.Collections.Generic;
    
    namespace EfCoreTest
    {
        public partial class Users
        {
            public Users()
            {
                InverseCreatedBy = new HashSet<Users>();
                InverseUpdatedBy = new HashSet<Users>();
            }
    
            public Guid CreatedById { get; set; }
            public Guid? UpdatedById { get; set; }
            public Guid Id { get; set; }
            public string Name { get; set; }
    
            public Users CreatedBy { get; set; }
            public Users UpdatedBy { get; set; }
            public ICollection<Users> InverseCreatedBy { get; set; }
            public ICollection<Users> InverseUpdatedBy { get; set; }
        }
    }
