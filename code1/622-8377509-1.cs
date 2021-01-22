    using System;
    using System.Collections.Generic; 
    using System.Linq; 
    using System.Text; 
    namespace tryingstartfror4digits 
    { 
    class Program 
    { 
        static void Main(string[] args)
        {
            Program pg=new Program();
            Console.WriteLine("Enter ur number");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num <= 19)
            {
                string g = pg.first(num);
                Console.WriteLine("The number is " + g);
            }
            else if ((num >= 20) && (num <= 99))
            {
                    if (num % 10 == 0)
                    {
                        string g = pg.second(num / 10);
                        Console.WriteLine("The number is " + g);
                    }
                    else
                    {
                        string g = pg.second(num / 10) + pg.first(num % 10);
                        Console.WriteLine("The number is " + g);
                    }
              }
            else if((num>=100) && (num<=999))
            {
                int k = num % 100;
                string g = pg.first(num / 100) +pg.third(0) + pg.second(k / 10)+pg.first(k%10);
                Console.WriteLine("The number is " + g);
              }
            else if ((num >= 1000) && (num <= 19999))
            {
                int h=num%1000;
               int k=h%100;
                string g = pg.first(num / 1000) + "Thousand " + pg.first(h/ 100) + pg.third(k) + pg.second(k / 10) + pg.first(k % 10);
                Console.WriteLine("The number is " + g);
            }
            Console.ReadLine();
        }
         public string first(int num)
        {
            string name;
            if (num == 0)
            {
                name = " ";
            }
            else
            {
                string[] arr1 = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" , "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};
                name = arr1[num - 1];
            }
            return name;
        }
        public string second(int num)
        {
            string name;
            if ((num == 0)||(num==1))
            {
             name = " ";
            }
            else
            {
                string[] arr1 = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                name = arr1[num - 2];
            }
            return name;
        }
        public string third(int num)
        {
            string name ;
            if (num == 0)
            {
                name = "";
            }
            else
            {
                string[] arr1 = new string[] { "Hundred" };
                name = arr1[0];
            }
            return name;
        }
    }
    }
