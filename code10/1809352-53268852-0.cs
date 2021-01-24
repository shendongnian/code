            var intArray = new List<int>(new int[array.Length]);
            for (int i = 0; i < array.Length; i++) 
            {
                intArray[i] = (int)Char.GetNumericValue(array.ElementAt(i));
            }
            var data = new List<int[]>();
            int n = 0;
            while (intArray.Skip(n).Take(span).ToArray().Length == span)
            {
                data.Add(intArray.Skip(n).Take(span).ToArray());
                n++;   
            }
            var list = new List<long>(data.Count());
            foreach (int[] nums in data)
            {
                list.Add((long)nums.Aggregate((total, next) => total * next));
            }
            long maxProduct = list.Max();
            return maxProduct;
