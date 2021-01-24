    namespace ZahidCarWash.Models
    {
        using System;
        using System.Collections.Generic;
    
        public class ServiceViewModel
        {
            public short ServiceID { get; set; }
            public string ServiceName { get; set; }
            public decimal ServicePrice { get; set; }
            public System.DateTime EntryDateTime { get; set; }
            public bool IsOwner { get; set; }
            public decimal Commission { get; set; }
        }
    }
