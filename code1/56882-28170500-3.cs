     private static void ArrayDeepCloneTest()
            {
                //a testing array
                CultureInfo[] secTestArray = { new CultureInfo("en-US", false), new CultureInfo("fr-FR") };
    
                //deep clone
                var secCloneArray = ArrayDeepCopy(secTestArray);
    
                //print out the cloned array
                Array.ForEach(secCloneArray, x => Console.WriteLine(x.DateTimeFormat.DateSeparator));
    
                //modify the original array
                secTestArray[0].DateTimeFormat.DateSeparator = "-";
    
                Console.WriteLine();
                //show the (deep) cloned array unchanged whereas a shallow clone would reflect the change...
                Array.ForEach(secCloneArray, x => Console.WriteLine(x.DateTimeFormat.DateSeparator));
            }
