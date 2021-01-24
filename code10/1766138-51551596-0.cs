            static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 9 };
            int[] b = { 4, 7, 2 };
            int position = 3;
            int count = 2;
            getresult(a, b, position, count);
            Console.ReadLine();
        }
 
                static void getresult(int[] a, int[] b,
                            int n, int m)
        {
            int firstArrayCount = 0;
            for(int i=0; i < n-1 ; i++)
            {
                Console.WriteLine(a[i]);
                firstArrayCount++;
            }
            for(int i=0; i < m ; i++)
            {
                Console.WriteLine(b[i]);
            }
            for(int i=firstArrayCount;i<a.Length;i++)
            {
                Console.WriteLine(a[i]);
            }
            for(int i=m;i<b.Length;i++)
            {
                Console.WriteLine(b[i]);
            }
        }
