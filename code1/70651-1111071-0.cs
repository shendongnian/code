        namespace ExtensionMethods
        {
            //static class
            public static class MyExtensions 
            {
                //static method with the first parameter being the object you are extending 
                //the return type being the type you are extending
                public static List<int> Swap(this List<int> list, 
                    int firstIndex, 
                    int secondIndex) 
    
                {
                    int temp = list[firstIndex];
                    list[firstIndex] = list[secondIndex];
                    list[secondIndex] = temp;
    
                    return list;
                }
            }   
        }
