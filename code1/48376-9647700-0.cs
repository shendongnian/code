    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void MESDYNR(int m, int s, int e, int d, int y, int n, int r, int v1, int v2, int v3)
            {
                // Solve for O in hundreds position
                // "SEND" + "M?RE" = "M?NEY"
                int carry = (10 * n + d + 10 * r + e) / 100;
                int o = (10 + n - (e + carry))%10;
    
                if ((v1 == o) || (v2 == o) || (v3 == o)) 
                {
                    // check O is valid in thousands position
                    if (o == ((10 + (100 * e + 10 * n + d + 100 * o + 10 * r + e) / 1000 + m + s) % 10))
                    {
                        // "SEND" + "MORE" = "MONEY"
                        int send = 1000 * s + 100 * e + 10 * n + d;
                        int more = 1000 * m + 100 * o + 10 * r + e;
                        int money = 10000 * m + 1000 * o + 100 * n + 10 * e + y;
    
                        // Chck this solution
                        if ((send + more) == money)
                        {
                            Console.WriteLine(send + " + " + more + " = " + money);
                        }
                    }
                }
            }
    
            static void MSEDYN(int m, int s, int e, int d, int y, int n, int v1, int v2, int v3, int v4)
            {
                // Solve for R
                // "SEND" + "M*?E" = "M*NEY"
                int carry = (d + e) / 10;
                int r = (10 + e - (n + carry)) % 10;
    
                if (v1 == r) MESDYNR(m, s, e, d, y, n, r, v2, v3, v4);
                else if (v2 == r) MESDYNR(m, s, e, d, y, n, r, v1, v3, v4);
                else if (v3 == r) MESDYNR(m, s, e, d, y, n, r, v1, v2, v4);
                else if (v4 == r) MESDYNR(m, s, e, d, y, n, r, v1, v2, v3);
            }
    
            static void MSEDY(int m, int s, int e, int d, int y, int v1, int v2, int v3, int v4, int v5)
            {
                // Pick any value for N
                MSEDYN(m, s, e, d, y, v1, v2, v3, v4, v5);
                MSEDYN(m, s, e, d, y, v2, v1, v3, v4, v5);
                MSEDYN(m, s, e, d, y, v3, v1, v2, v4, v5);
                MSEDYN(m, s, e, d, y, v4, v1, v2, v3, v5);
                MSEDYN(m, s, e, d, y, v5, v1, v2, v3, v4);
            }
    
            static void MSED(int m, int s, int e, int d, int v1, int v2, int v3, int v4, int v5, int v6)
            {
                // Solve for Y
                // "SE*D" + "M**E" = "M**E?"
                int y = (e + d) % 10;
    
                if (v1 == y) MSEDY(m, s, e, d, y, v2, v3, v4, v5, v6);
                else if (v2 == y) MSEDY(m, s, e, d, y, v1, v3, v4, v5, v6);
                else if (v3 == y) MSEDY(m, s, e, d, y, v1, v2, v4, v5, v6);
                else if (v4 == y) MSEDY(m, s, e, d, y, v1, v2, v3, v5, v6);
                else if (v5 == y) MSEDY(m, s, e, d, y, v1, v2, v3, v4, v6);
                else if (v6 == y) MSEDY(m, s, e, d, y, v1, v2, v3, v4, v5);
            }
    
            static void MSE(int m, int s, int e, int v1, int v2, int v3, int v4, int v5, int v6, int v7)
            {
                // "SE**" + "M**E" = "M**E*"
                // Pick any value for D
                MSED(m, s, e, v1, v2, v3, v4, v5, v6, v7);
                MSED(m, s, e, v2, v1, v3, v4, v5, v6, v7);
                MSED(m, s, e, v3, v1, v2, v4, v5, v6, v7);
                MSED(m, s, e, v4, v1, v2, v3, v5, v6, v7);
                MSED(m, s, e, v5, v1, v2, v3, v4, v6, v7);
                MSED(m, s, e, v6, v1, v2, v3, v4, v5, v7);
                MSED(m, s, e, v7, v1, v2, v3, v4, v5, v6);
            }
    
       
            static void MS(int m, int s, int v1, int v2, int v3, int v4, int v5, int v6, int v7, int v8)
            {
                // "S***" + "M***" = "M****"
                // Pick any value for E
                MSE(m, s, v1, v2, v3, v4, v5, v6, v7, v8);
                MSE(m, s, v2, v1, v3, v4, v5, v6, v7, v8);
                MSE(m, s, v3, v1, v2, v4, v5, v6, v7, v8);
                MSE(m, s, v4, v1, v2, v3, v5, v6, v7, v8);
                MSE(m, s, v5, v1, v2, v3, v4, v6, v7, v8);
                MSE(m, s, v6, v1, v2, v3, v4, v5, v7, v8);
                MSE(m, s, v7, v1, v2, v3, v4, v5, v6, v8);
                MSE(m, s, v8, v1, v2, v3, v4, v5, v6, v7);
             }
    
            static void Main(string[] args)
            {
                // M must be 1
                // S must be 8 or 9
                DateTime Start = DateTime.Now;
                MS(1, 8, 2, 3, 4, 5, 6, 7, 9, 0);
                MS(1, 9, 2, 3, 4, 5, 6, 7, 8, 0);
                Console.WriteLine((DateTime.Now-Start).Milliseconds);
                return;
            }
        }
    }
