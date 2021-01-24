        public static int[] GetUniqueInt(int intCount, int intLength)
        {
            int[] returnValue = new int[intCount];
            var values = new HashSet<int>();
            for (int i = 0; u < intCount; ++i)
            {
                // Generate the number and check to be sure we haven't seen it yet
                var number = GetRandomInt(intCount);
                while(values.Contains(number)) number = GetRandomInt(intCount);
   
                // Add the number to the return array and add it to the list of seen numbers             
                returnValue[a] = number;
                values.Add(number);
            }
            Debug.Log(returnValue);
            return returnValue;
        }
