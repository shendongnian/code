    var sb = new StringBuilder();
    foreach(var c in txt)
    {
        if (c == '{') sb.Append("{{}");
        else if (c == '}') sb.Append("{}}");
        else sb.Append(c);
    }
    SendKeys.Send(sb.ToString());
