    using System;
    
    public class Program
    {
       // Main method begins execution of C# application
       public static void Main(string[] args)
       {
          int[] array = new int[5];
    
          for (int i = 0; i < array.Length; i++)
          {
             Console.WriteLine("Enter a number:");
    // you are putting the value into your array here.  so it will always 'exist' below
             array[i] = Convert.ToInt32(Console.ReadLine());  
    
    // you need to do this check before you insert the number into the array
    // put the ReadLine into a variable, not directly into the array.  
    // then check if it's in the array already 
             for (int a = 0; a < 5; a++)
             {
    
                if (array[i] != array[a])
                {
    // here you are trying to read another value from the user.  
    // Console.ReadLine() will always wait for user input
    // use the variable from above.  but only after you have looped through all the items.
    // and verified that it is not present
                   array[i] = int.Parse(Console.ReadLine());
                   Console.WriteLine("new\n");
                }
    
             }
    // this is the third time you have assigned the number to the array
    // and the third time you've asked for user input per loop
             array[i] = int.Parse(Console.ReadLine());
             Console.WriteLine("exists\n");
          }
    
          Console.WriteLine(array);
          Console.ReadKey();
       }
    } // end class
