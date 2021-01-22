    namespace OptionalParameterWithOptionalAttribute
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Calling the helper method Hello only with required parameters
                Hello("Vardenis", "Pavardenis");
                //Calling the helper method Hello with required and optional parameters
                Hello("Vardenis", "Pavardenis", "Palanga");
            }
            public static void Hello(string firstName, string secondName, 
                [System.Runtime.InteropServices.OptionalAttribute] string  fromCity)
            {
                string result = firstName + " " + secondName;
                if (fromCity != null)
                {
                    result += " from " + fromCity;
                }
                Console.WriteLine("Hello " + result);
            }
    
        }
    }
