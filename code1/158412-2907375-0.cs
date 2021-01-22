       // iterate through Volume enum by name
        public void ListEnumMembersByName()
        {
            Console.WriteLine("\n---------------------------- ");
            Console.WriteLine("Volume Enum Members by Name:");
            Console.WriteLine("----------------------------\n");
    
            // get a list of member names from Volume enum,
            // figure out the numeric value, and display
            foreach (string volume in Enum.GetNames(typeof(Volume)))
            {
                Console.WriteLine("Volume Member: {0}\n Value: {1}",
                    volume, (byte)Enum.Parse(typeof(Volume), volume));
            }
        }
    
        // iterate through Volume enum by value
        public void ListEnumMembersByValue()
        {
            Console.WriteLine("\n----------------------------- ");
            Console.WriteLine("Volume Enum Members by Value:");
            Console.WriteLine("-----------------------------\n");
    
            // get all values (numeric values) from the Volume
            // enum type, figure out member name, and display
            foreach (byte val in Enum.GetValues(typeof(Volume)))
            {
                Console.WriteLine("Volume Value: {0}\n Member: {1}",
                    val, Enum.GetName(typeof(Volume), val));
            }
        }
    }
