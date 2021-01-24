    using System;
    using System.Text.RegularExpressions;
    class Test
    {
      static void Main(string[] args)
        {
          String sourcestring = @"sdfso dadfjlsdfjksdjfkjsd
    sdfso dadfjlsdfjksdjfkjsd
    T1234567898dssdkfjskfjksdj
    T1234567890dssdkfjskfjksdj
    sdfso dadfjlsdfjksdjfkjsd
    T1234567891dssdkfjskfjksdj";
          String matchpattern = @"(?=\DT\d{10}\D)";
          Regex re = new Regex(matchpattern); 
          String[] splitarray = re.Split(sourcestring);
            for(int sIdx = 0; sIdx < splitarray.Length; sIdx++ ) {
              Console.WriteLine("[{0}] = {1}", sIdx, splitarray[sIdx].Trim());
            }
        }
    }
