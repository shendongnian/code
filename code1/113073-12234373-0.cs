    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;
    
    namespace ConsoleApplication6
    {
    
        // use this class if you plan to add lots more settings files in future (low maintenance)
        class GenericProps1 
        {
            public string TestString { get; private set; }
    
            // note ApplicationSettingsBase
            public static explicit operator GenericProps1(ApplicationSettingsBase props)
            {
                return new GenericProps1() { TestString = props.Properties["TestString"].DefaultValue.ToString() };
            }
        }
    
        // use this class if you do not plan to add more settings files in future (nicer code)
        class GenericProps2 
        {
            public string TestString { get; private set; }
    
            // cast needed for settings1 file
            public static explicit operator GenericProps2(Properties.Settings1 props)
            {
                return new GenericProps2() { TestString = props.TestString };
            }
    
            // cast needed for settings 2 file
            public static explicit operator GenericProps2(Properties.Settings2 props)
            {
                return new GenericProps2() { TestString = props.TestString };
            }
    
            // cast for settings 3,4,5 files go here...
        }
    
    
        class Program
        {
            // usage
            static void Main(string[] args)
            {
                GenericProps1 gProps1_1 = (GenericProps1)Properties.Settings1.Default;
                GenericProps1 gProps1_2 = (GenericProps1)Properties.Settings1.Default;
                //or
                GenericProps2 gProps2_1 = (GenericProps2)Properties.Settings1.Default;
                GenericProps2 gProps2_2 = (GenericProps2)Properties.Settings1.Default;
            }
        }
    
    }
