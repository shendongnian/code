            static void Main(string[] args)
            {
                int noofelement;
                do
                {
                    Console.WriteLine("Could you please provide the total numbers of elements of this array?");
                } while (!int.TryParse(Console.ReadLine(),out noofelement));
    
    
                int[] A = new int[noofelement] ;
    
                for (int i = 1; i <= noofelement; i++)
                {
                    A[i-1] = (1 / i * i);
                    Console.WriteLine(A[i-1]);
                }
                Console.ReadLine();
            }
