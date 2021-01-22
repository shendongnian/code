    int chr = 0;
    string pass = "";
    const int ENTER = 13;
    const int BS = 8;
    do
    {
       chr = Console.ReadKey().KeyChar;
       Console.Clear(); //imediately clear the char you printed
       //if the char is not 'return' or 'backspace' add it to pass string
       if (chr != ENTER && chr != BS) pass += (char)chr;
       //if you hit backspace remove last char from pass string
       if (chr == BS) pass = pass.Remove(pass.Length-1, 1);
       for (int i = 0; i < pass.Length; i++)
       {
          Console.Write('*');
       }
    } 
     while (chr != ENTER);
    Console.Write("\n");
    Console.Write(pass);
    Console.Read(); //just to see the pass
    
