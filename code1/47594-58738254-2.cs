string blink = "Password Please!"
while (!System.Console.KeyAvailable)
   {
      Console.Write(blink);
      Thread.Sleep(650);
      for (int j = 1; j <= blink.Length + 2; j++)
          {
             Console.Write("\b"+(char)32+"\b");
             if (j == blink.Length + 2) Thread.Sleep(650);
          }
   }
- - - 
  [1]: https://i.stack.imgur.com/JollQ.gif
