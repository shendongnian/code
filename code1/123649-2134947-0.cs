    using (FileStream fs = new FileStream(filename, FileMode.Open)) 
    using (StreamReader rdr = new StreamReader(fs)) { 
      rdr.ReadLine(); // skip the first line
      string line = null;
      while ((line = rdr.ReadLine()) != null) {
        string[] lines = line.Split('|');
        sb.AppendLine(";Re"); 
        sb.AppendLine("@C PAMT " + lines[3]); 
        sb.AppendLine("@T " + lines[0]); 
        sb.AppendLine("@D @I\\" + lines[1]).Replace("I:\\", ""); 
        sb.AppendLine(lines[2].Replace(";", "\r\n"); 
      }
    } 
    
    if (sb.Length == 0) return; // return if nothing was processed
    
    using (FileStream fs = new FileStream(outputfilename, FileMode.Create)) 
    using (StreamWriter writer = new StreamWriter(fs)) 
    { 
        writer.Write(sb.ToString()); 
    } 
