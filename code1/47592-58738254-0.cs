string blink = "Press any key to continue!"
while (!System.Console.KeyAvailable)
   {
      Console.Write("Press any key to continue!");
      Thread.Sleep(650);
      for (int j = 1; j <= blink.Length + 2; j++)
          {
             Console.Write("\b"+(char)32+"\b");
             if (j == blink.Length + 2) Thread.Sleep(650);
          }
   }
- - - 
