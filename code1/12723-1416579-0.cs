            /*This throws an exception
            foreach (string s in arr)
            {
                arr.Remove(s);
            }
            */
 
            //where as this works correctly
            Console.WriteLine(arr.Count);
            foreach (string s in new System.Collections.ArrayList(arr)) 
            {
                arr.Remove(s);
            }
            Console.WriteLine(arr.Count);
            Console.ReadKey();
