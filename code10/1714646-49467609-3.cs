    while (choice == "Y")
    {
         Console.WriteLine("Enter Username : ");
         chkusername = Console.ReadLine();
         if(names.Contains(chkusername))
             Console.WriteLine("Name already entered");
         else
         {
            Console.WriteLine("Enter a Password : ");
            password = Console.ReadLine();
            names.Add(chkusername);
            // Write the file in append mode and close/dispose it
            using(StreamWriter sw = new StreamWriter("Users.txt",true))
                sw.WriteLine(chkusername + "#" + password);
         }
         Console.WriteLine("Continue? Y/N");
         choice = Console.ReadLine();
    }
