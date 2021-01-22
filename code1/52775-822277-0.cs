    String myString = "patt\b\b\b\b\b\b\b\b\b\bfoo";
          List<char> chars = myString.ToCharArray().ToList();
          int delCount = 0;
    
          for (int i = chars.Count -1; i >= 0; i--)
          {
            if (chars[i] == '\b')
            {
              delCount++;
              chars.RemoveAt(i);
            } else {
              if (delCount > 0 && chars[i] != null) {
                chars.RemoveAt(i);
                delCount--;
              }
            }
          }
