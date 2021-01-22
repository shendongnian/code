        private static void MergeTwoSortedArray(int[] first, int[] second)
        {
            //throw new NotImplementedException();
            int[] result = new int[first.Length + second.Length];
            int i=0 , j=0 , k=0;
            while(i < first.Length && j <second.Length)
            {
                if(first[i] < second[j])
                {
                    result[k++] = first[i++];
                }
                else
                {
                    result[k++] = second[j++];
                }
            }
            if (i < first.Length)
            {
                for (int a = i; a < first.Length; a++)
                    result[k] = first[a];
            }
            if (j < second.Length)
            {
                for (int a = j; a < second.Length; a++)
                    result[k++] = second[a];
            }
            foreach (int a in result)
                Console.Write(a + " ");
            Console.WriteLine();
        }
