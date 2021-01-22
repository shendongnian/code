    Byte[] bytes = new Byte[20];
    String str = "blah";
    
    System.Text.ASCIIEncoding  encoding = new System.Text.ASCIIEncoding();
    bytes = encoding.GetBytes(str);
