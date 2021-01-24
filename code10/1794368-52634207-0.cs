    do { 
         Console.WriteLine("Please enter how many characters the string you want encrypyted to be:");
         userlength = Convert.ToInt64(Console.ReadLine());
         Console.WriteLine("Please enter the string you want to be encrypted:");
         unencrypted = Console.ReadLine();
         int[] first = new int[userlength];
         int[] second = new int[userlength];
         if (userlength != unencrypted.Length)
         {
            Console.WriteLine("The string you entered was not the same length as the number of characters you specified");
         }   
    } while(userlength != unencrypted.Length);
 
         
