        public class Criteria
        {
            private DateTime from { get; set; }
            private DateTime to { get; set; }
            /// <summary>
            /// Gets or sets the city.
            /// </summary>
            /// <value>The city.</value>
            public string From { 
                get { 
                    return from.ToString("yyyy-mm-dd");
                }
     
                set { 
                    from = DateTime.ParseExact("yyyy-mm-dd",value, System.Globalization.CultureInfo.InvariantCulture);
                }
            }
           public string To {
               get {
                   return to.ToString("yyyy-mm-dd");
               }
     
                set { 
                    to = DateTime.ParseExact("yyyy-mm-dd",value, System.Globalization.CultureInfo.InvariantCulture);
                }
            }
        }
