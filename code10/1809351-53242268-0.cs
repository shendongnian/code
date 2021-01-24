    var intArray = new List<int>(new int[span]);
    
                for (int i = 0; i < span; i++)
                {
                    intArray.Add((int)Char.GetNumericValue(array.ElementAt(i)));
                }
