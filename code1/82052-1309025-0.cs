    for (int i = 0; i < b.Length; i++)
    {
      byte curByte = b[i];
      // Assuming that the first byte of a 2-byte character sequence will be 0
      if (curByte != 0)
      { 
        // This is a 1 byte number
        Console.WriteLine(Convert.ToString(curByte));
      }
      else
      { 
        // This is a 2 byte character. Print it out.
        Console.WriteLine(Encoding.Unicode.GetString(b, i, 2));
        // We consumed the next character as well, no need to deal with it
        //  in the next round of the loop.
        i++;
      }
    }
