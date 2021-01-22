        private static string[][] SliceArray(string[] source, int maxResultElements)
        {
            int numberOfArrays = source.Length / maxResultElements;
            if (maxResultElements * numberOfArrays < source.Length)
                numberOfArrays++;
            string[][] target = new string[numberOfArrays][];
            for (int index = 0; index < numberOfArrays; index++)
            {
                int elementsInThisArray = Math.Min(maxResultElements, source.Length - index * maxResultElements);
                target[index] = new string[elementsInThisArray];
                Array.Copy(source, index * maxResultElements, target[index], 0, elementsInThisArray);
            }
            return target;
        }
