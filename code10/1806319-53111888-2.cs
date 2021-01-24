    List<string> tools = new List<string>()
    {
        "Hammer", "Wrench", "Screwdriver", "etc"
    };
    List<string> output = new List<string>();
    int count = 1;
    foreach ( string toolName in tools )
    {
        if (count ==  62)
        {
            output.Insert ( count , "some string" );
            count++;
            continue;
        }
        output.Add ( "[\"at" + count.ToString ( "D4" ) + "\"] = < " );
        output.Add ( "[\"at" + count.ToString ( "D4" ) + "\"] = < " );
        output.Add ( "text = < \"" + toolName + "\" >" );
        output.Add ( "description = <\" * \">" );
        output.Add ( ">" );
        count++;
    }
    string path = @"C:\output.txt";
    File.WriteAllLines ( path , output.ToArray ( ) );
