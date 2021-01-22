    static void Main(string[] args)
        {
            int[] Num =new int[] { 3, 4, 5, 6, 7, 0,99,105,55 };
            int temp;
            for(int a=0;a<Num.Length-1;a++)
            {
                for(int b=a+1;b<Num.Length;b++)
                {
                    if(Num[a]>Num[b])
                    {
                        temp = Num[a];
                        Num[a] = Num[b];
                        Num[b] = temp;
                    }
                }
            }
            
            Console.WriteLine("Max value ="+Num[Num.Length-1]+"\nSecond largest Max value="+ Num[Num.Length - 2]+"\nMin value =" + Num[0] + "\nSecond smallest Min value=" + Num[1]);
            Console.WriteLine("\nPress to close");
            Console.ReadLine();
        }
