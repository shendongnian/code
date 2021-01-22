    public unsafe struct poly { public int coef; public int pow; public poly* link; }
    public unsafe class Program
    {
        static void Main(string[] args)
        {            
            poly* temp1, temp2, start =
                (poly*)Marshal.AllocHGlobal(sizeof(poly)).ToPointer();
            start->coef = 0;
            start->pow = 0;
            temp1 = start;
            for (int i = 1; i < 10; i++)
            {
                temp2 = (poly*)Marshal.AllocHGlobal(sizeof(poly)).ToPointer();
                temp2->coef = i;
                temp2->pow = i;
                temp1->link = temp2;
                temp1 = temp2;
            }
            temp1->link = null;
            temp1 = start;
            while (temp1 != null)
            {
                Console.WriteLine(
                    string.Format(
                        "eoef:{0}, pow:{1}", 
                        temp1->coef, 
                        temp1->pow));
                temp1 = temp1->link;
            }
        }
    }
