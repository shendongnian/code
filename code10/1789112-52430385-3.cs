    using System;
    
    class MainClass {
      public static void Main (string[] args) {
    			  int length;
    			  int height;
    
                  bool loop1 = true; 
                  while(loop1)
                  {
                    Console.WriteLine("\nEnter the base length");
                    try
                    {
                    length = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\nInvalid Entry: "+ex.Message);
                        continue;
                    }
    
                    Console.WriteLine("\nEnter the perpendicular height");
                    try
                    {
                    height = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("\nInvalid Entry: "+ex.Message);
                    }
                    Console.WriteLine(area(length,height));
                    }
      }
                static int area(int length, int height)
                  {
                    return length * height/2;
                  }
    }
