    StringBuilder sb;
    List<string> lines = ....;
    sb.Append(">>> [").Append(lines[0]);
    for (int idx = 1; idx < lines.Count; idx++)
        sb.Append("], [").Append(lines[idx]);
    sb.Append("] <<<");
