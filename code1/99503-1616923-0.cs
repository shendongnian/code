            int[] a= {1,2,3,4,5,6,7,8,9,10};
            int StartIndex=5;
            for (int iCount = StartIndex; iCount < a.Count() + StartIndex; iCount++)
            {
                Debug.WriteLine(a[(iCount + a.Count()) % a.Count()]);
            }
