    class Scanner : System.IO.StringReader
    {
      string currentWord;
      public Scanner(string source) : base(source)
      {
         readNextWord();
      }
      private void readNextWord()
      {
         System.Text.StringBuilder sb = new StringBuilder();
         string nextChar;
         int next;
         do
         {
            next = this.Read();
            if (next < 0)
               break;
            nextChar = char.ConvertFromUtf32(next);
            if (char.IsWhiteSpace(nextChar[0]))
               break;
            sb.Append(nextChar);
         } while (true);
         while((this.Peek() >= 0) && (char.IsWhiteSpace(char.ConvertFromUtf32(this.Peek())[0])))
            this.Read();
         if (sb.Length > 0)
            currentWord = sb.ToString();
         else
            currentWord = null;
      }
      public bool hasNextInt()
      {
         if (currentWord == null)
            return false;
         int dummy;
         return int.TryParse(currentWord, out dummy);
      }
      public int nextInt()
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
      public bool hasNextDouble()
      {
         if (currentWord == null)
            return false;
         double dummy;
         return double.TryParse(currentWord, out dummy);
      }
      public double nextDouble()
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
      public bool hasNext()
      {
         return currentWord != null;
      }
    }
