       List<String> strings=new List<string>();
    
    
            Console.WriteLine(strings.GetType().GetGenericTypeDefinition());
            foreach (var t in strings.GetType().GetGenericArguments())
            {
                Console.WriteLine(t);
    
            }
