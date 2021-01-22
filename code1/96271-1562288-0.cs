    class Scanner : System.IO.StringReader
    {
      string currentWord;
    
      public Scanner(string source) : base(source)
      {
         readNextWord();
      }
    
      private void ReadNextWord()
      {
         System.Text.StringBuilder sb = new StringBuilder();
         char nextChar;
         int next;
         do
         {
            next = this.Read();
            if (next < 0)
               break;
            nextChar = (char)next;
            if (char.IsWhiteSpace(nextChar))
               break;
            sb.Append(nextChar);
         } while (true);
         while((this.Peek() >= 0) && (char.IsWhiteSpace((char)this.Peek())))
            this.Read();
         if (sb.Length > 0)
            currentWord = sb.ToString();
         else
            currentWord = null;
      }
    
      public bool HasNextInt()
      {
         if (currentWord == null)
            return false;
         int dummy;
         return int.TryParse(currentWord, out dummy);
      }
    
      public int NextInt()
      {
         try
         {
            return int.Parse(currentWord);
         }
         finally
         {
            readNextWord();
         }
      }
    
      public bool HasNextDouble()
      {
         if (currentWord == null)
            return false;
         double dummy;
         return double.TryParse(currentWord, out dummy);
      }
    
      public double NextDouble()
      {
         try
         {
            return double.Parse(currentWord);
         }
         finally
         {
            readNextWord();
         }
      }
    
      public bool HasNext()
      {
         return currentWord != null;
      }
    }
