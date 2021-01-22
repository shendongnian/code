            // abstracted enumeration value
            Enum abstractEnum = null;
            
            // set to the Console-Color enumeration value "Blue";
            abstractEnum = System.ConsoleColor.Blue;
            // the defined value of "ConsoleColor.Blue" is "9":
            // you can get the value via the ToObject method:
            Console.WriteLine((int)Enum.ToObject(abstractEnum.GetType(), abstractEnum));
            // or via the GetHashCode() method:
            Console.WriteLine(abstractEnum.GetHashCode());
            // the name can also be acessed:
            Console.WriteLine(Enum.GetName(abstractEnum.GetType(), abstractEnum));
    
