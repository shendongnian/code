    public static bool CheckString(string input) {
      if (string.IsNullOrEmpty(input))
        return true;
      Stack<char> brackets = new Stack<char>();
      foreach (var c in input) {
        if (c == '[' || c == '{' || c == '(')
          brackets.Push(c);
        else if (c == ']' || c == '}' || c == ')') {
          // Too many closing brackets, e.g. (123))
          if (!brackets.Any())
            return false;
          char open = brackets.Pop();
          // Inconsistent brackets, e.g. (123]
          if (c == '}' && open != '{' ||
              c == ')' && open != '(' ||
              c == ']' && open != '[')
            return false;
        }
      }
      // Too many opening brackets, e.g. ((123) 
      if (brackets.Any())
        return false;
      return true;
    }
