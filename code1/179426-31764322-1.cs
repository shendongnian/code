     string pass = "";
     Console.WriteLine("Enter your password: ");
     ConsoleKeyInfo key;
    
     do {
      key = Console.ReadKey(true);
    
      if (key.Key != ConsoleKey.Backspace) {
       pass += key.KeyChar;
       Console.Write("*");
      } else {
       Console.Write("\b \b");
       char[] pas = pass.ToCharArray();
       string temp = "";
       for (int i = 0; i < pass.Length - 1; i++) {
        temp += pas[i];
       }
       pass = temp;
      }
     }
     // Stops Receving Keys Once Enter is Pressed
     while (key.Key != ConsoleKey.Enter);
    
     Console.WriteLine();
     Console.WriteLine("The Password You entered is : " + pass);
