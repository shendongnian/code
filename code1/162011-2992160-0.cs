    writer.WriteString(lines[0].TrimEnd().Split(ca, 2)[1]);
    
    string[] splitLine = lines[0].TrimEnd().Split(ca,2);
    if(splitLine.Length >1)
      writer.WriteString(splitLine[1]);
