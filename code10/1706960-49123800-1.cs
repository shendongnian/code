    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    namespace ClientConsultationSystem
    {
        public class Rates
        {
            public Rates() { }  // the constructor
            public double SGD { get; set; }
        }
        public class Item
        {
            public Item() {
                r = new Rates;  // requires Rates have a constructor
            }
            public string b { get; set; }
            public string d { get; set; }
            public Rates r { get; set; }
        }
    }
