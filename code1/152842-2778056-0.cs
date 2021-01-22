    using System;
    using System.Reflection;
    
    [assembly: AssemblyTitle("CustAttrs1CS")]
    [assembly: AssemblyDescription("GetCustomAttributes() Demo")]
    [assembly: AssemblyCompany("Microsoft")]
    
    namespace CustAttrs1CS {
        class DemoClass {
            static void Main(string[] args) {
                Type clsType = typeof(DemoClass);
                // Get the Assembly type to access its metadata.
                Assembly assy = clsType.Assembly;
    
                // Iterate through the attributes for the assembly.
                foreach(Attribute attr in Attribute.GetCustomAttributes(assy)) {
                    // Check for the AssemblyTitle attribute.
                    if (attr.GetType() == typeof(AssemblyTitleAttribute))
                        Console.WriteLine("Assembly title is \"{0}\".",
                            ((AssemblyTitleAttribute)attr).Title);
    
                    // Check for the AssemblyDescription attribute.
                    else if (attr.GetType() == 
                        typeof(AssemblyDescriptionAttribute))
                        Console.WriteLine("Assembly description is \"{0}\".",
                            ((AssemblyDescriptionAttribute)attr).Description);
    
                    // Check for the AssemblyCompany attribute.
                    else if (attr.GetType() == typeof(AssemblyCompanyAttribute))
                        Console.WriteLine("Assembly company is {0}.",
                            ((AssemblyCompanyAttribute)attr).Company);
                }
            }
        }
    }
