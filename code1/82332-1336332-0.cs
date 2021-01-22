    StringBuilder sb;
    byte[] b;
    do
    {
     b = commPort.Read(1);
     sb.Append(Encoding.ASCII.GetChars(b));
     Thread.Sleep(20); //symbol is slow... 
    } while(b.Length > 0);
