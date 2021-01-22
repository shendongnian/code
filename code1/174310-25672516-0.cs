      static void Main(string[] args)
        {
            String input = Console.ReadLine();
            long num = Convert.ToInt32(input);
            long a, b, c;
            c = 2;
            for(long i=3; i<=num; i++){
                b = 0;
                for (long j = 2; j < i ; j++) {
                    a = i % j;
                    if (a != 0) {
                        b = b+1;
                    }
                    else {
                        break;
                    }
                }
                
                if(b == i-2){
                    Console.WriteLine("{0}",i);
                }
            }
            Console.ReadLine();
        }
