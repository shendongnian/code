    private static void CheckBoundaries<T>(T[] sourceArray, long sourceIndex, T[] destinationArray, long copyNoOfElements, long sourceArrayLength)
            {
                if (sourceIndex >= sourceArray.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                if (copyNoOfElements > sourceArrayLength)
                {
                    throw new IndexOutOfRangeException();
                }
                if (destinationArray.Length < copyNoOfElements)
                {
                    throw new IndexOutOfRangeException();
                }
            }
