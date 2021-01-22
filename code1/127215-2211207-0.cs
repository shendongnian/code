    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
            }
        }
    
        class DataAccessLayer
        {
            public PropertyBase GetSomething(int id)
            {
                if (id > 10)
                    return new CommercialProperty();
                else
                    return new ResidentialProperty();
            }
    
        }
    
        class PropertyBase { }
        class ResidentialProperty : PropertyBase { } 
        class CommercialProperty : PropertyBase { }
    }
