    string line;
    StreamReader reader = new StreamReader(filePath);
    while(null != (line = reader.Read())
    {
       //You have to create the constant COMMA_SEP
       string split = line.Split(COMMA_SEP);
    }
