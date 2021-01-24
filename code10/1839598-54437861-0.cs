    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;
    
    namespace Reflection_Test
    {
        class UserControl
        {
            public int test { get; set; } // if no getter/setter is set, this is considered as field, not property
            public bool falsetrue { get; set; } // if no getter/setter is set, this is considered as field, not property
            public UserControl control { get; set; } // if no getter/setter is set, this is considered as field, not property
    
            public UserControl()
            {
                test = 23;
                falsetrue = true;
                control = this;
            }
    
            public List<string> GetAttributes()
            {
                PropertyInfo[] temp = this.GetType().GetProperties();
                    //this.GetType().GetProperties();
                List<string> result = new List<string>();
                
                foreach(PropertyInfo prop in temp)
                {
                    result.Add(prop.PropertyType.ToString());
                }
                
                return result;
            } 
    
        }
    }
