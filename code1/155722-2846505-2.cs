    class SomeClass
    {
        public static void VerifyNullArgument(params object objects)
        {
            if (objects == null)
            {
                throw new ArgumentNullException("objects");
            }
            for (int index = 0; index < objects.Lenght; index++)
            {
                if (objects[index] == null)
                {
                    throw new ArgumentException("Element is null at index " + index,
                        "objects");
                }
            }
        }
    }
