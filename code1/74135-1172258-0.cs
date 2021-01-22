    public static string GetTextAfterMarker(string line, string marker)
    {
    	string items[] = line.Split(new string[] { marker }, StringSplitOptions.None);
    	
          if(items.Length > 0)
              return items[items.Length - 1];
          else
              return string.Empty;
    }
