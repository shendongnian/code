    namespace ZahidCarWash.Models.EF
    {
        using System;
        using System.Collections.Generic;
    
        public partial class Services
        {
            public short ServiceID { get; set; }
            public string ServiceName { get; set; }
            public Nullable<decimal> ServicePrice { get; set; }
            public Nullable<System.DateTime> EntryDateTime { get; set; }
            public Nullable<bool> IsOwner { get; set; }
            public Nullable<decimal> Commission { get; set; }
        }
    }
