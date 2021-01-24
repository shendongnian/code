    public IMergeable[] mergeTwoSorted<Tone, Ttwo> (Tone[] array, Ttwo[] array2)
        where Tone : IMergeable, Ttwo : IMergeable
        {
            IMergeable[] mergedArray = new IMergeable[array.Length + array2.Length];
            for (int i = 0; i < mergedArray.Length; i++)
            {
                if (array is ValueType && array2 is ValueType)
                {
                    if (array[i] > array2[i])
    
                }
            }
        }
