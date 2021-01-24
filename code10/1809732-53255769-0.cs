    StringBuilder sb=new StringBuilder();
    foreach (var info in linqData)
    {
     sb.Append(info.Count);
     sb.Append(";");
     sb.Append(info.Line);
     sb.Append(Environment.Newline); 
    }
    MessageBox.Show(sb.ToString());
