    static class Global
    {
        public static bool ArraysAreEqual(Array arr1, Array arr2)
        {
            if (arr1.Length != arr2.Length)
                return false;
            System.Collections.IEnumerator e1 = arr1.GetEnumerator();
            System.Collections.IEnumerator e2 = arr2.GetEnumerator();
            
            while(e1.MoveNext() && e2.MoveNext())
            {
                if(!e1.Current.Equals(e2.Current))
                    return false;
            }
            return true;
        }
    }
