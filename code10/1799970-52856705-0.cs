    public static class ListExtensions
    {
        public static int SomeAddOperation(this List<ObjectName> listA, List<ObjectName> listB)
        {
            int sumA = 0;
            foreach(var someObject in listA)
            {
                sumA += someObject.Value;
            }
        
            int sumB = 0;
            foreach(var someObject in listB)
            {
                sumB += someObject.Value;
            }        
            return sumA + sumB;
        }
    }
