        public static int solution1(int A, int B)
        {
            // Check if A and B are in [0...999,999,999]
            if ( (A >= 0 && A <= 999999999) && (B >= 0 && B <= 999999999))
            {
                if (A == 0 && B == 0)
                {
                    return 0;
                }
                // Make sure A < B
                if (A < B)
                {                    
                    // Convert A and B to strings
                    string a = A.ToString();
                    string b = B.ToString();
                    int index = 0;
                    // See if A is a substring of B
                    if (b.Contains(a))
                    {
                        // Find index where A is
                        if (b.IndexOf(a) != -1)
                        {                            
                            while ((index = b.IndexOf(a, index)) != -1)
                            {
                                Console.WriteLine(A + " found at position " + index);
                                index++;
                            }
                            Console.ReadLine();
                            return b.IndexOf(a);
                        }
                        else
                            return -1;
                    }
                    else
                    {
                        Console.WriteLine(A + " is not in " + B + ".");
                        Console.ReadLine();
                        return -1;
                    }
                }
                else
                {
                    Console.WriteLine(A + " must be less than " + B + ".");
                   // Console.ReadLine();
                    return -1;
                }                
            }
            else
            {
                Console.WriteLine("A or B is out of range.");
                //Console.ReadLine();
                return -1;
            }
        }
        static void Main(string[] args)
        {
            int A = 53, B = 1953786;
            int C = 78, D = 195378678;
            int E = 57, F = 153786;
            solution1(A, B);
            solution1(C, D);
            solution1(E, F);
            Console.WriteLine();
        }
