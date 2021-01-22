    StringBuilder newPath = new StringBuilder();
    // Do this to remove any dodgy characters in the path like a ? at end
    char[] inValidChars = Path.GetInvalidPathChars();
    foreach (Char c in oldPath.ToCharArray())
    {
        if (inValidChars.Contains(c) == false && c != '?')
        {
            newPath.Append(c);
        }
    }
