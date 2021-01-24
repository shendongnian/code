    var sb = new StringBuilder(txt.Length);
    for(var i = 0; i < txt.Length; i++)
    {
        var c = txt[i];
        switch (c)
        {
          case '+':
          case '^':
          case '%':
          case '~':
          case '(':
          case ')':
          case '[':
          case ']':
          case '{':
          case '}':
            sb.Append('{');
            sb.Append(c);
            sb.Append('}');
            break;
          default:
            sb.Append(c);
            break;
        }
    }
    SendKeys.Send(sb.ToString());
