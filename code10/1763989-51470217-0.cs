     private static void InvokeFunctionDynamically<T>(T data)
        {            
            //1. Define the delegate 
            Func<string, bool, T> genericFunction = (name, isEnabled) =>
            {
                if(isEnabled)
                {
                    return data;
                }
                return default(T);
            };
            // 2. demonstrate that the delegate is retrieved at the run time as an object
            object runtimeObject = genericFunction;
            
            //3. Cast it directly to the delegate type
            var result =((Func<string, bool, T>) runtimeObject)("hello", true);
            Console.WriteLine($"Result {result}");
        }
