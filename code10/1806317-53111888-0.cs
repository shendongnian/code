    List<string> tools = new List<string>()
    {
        "Hammer", "Wrench", "Screwdriver", "etc"
    };
    List<string> output = new List<string>();
    int count = 0;
    foreach ( string toolName in tools )
    {
        output.Add ( "[\"at" + count.ToString ( "D4" ) + "\"] = < " );
        output.Add ( "[\"at" + count.ToString ( "D4" ) + "\"] = < " );
        output.Add ( "text = < \"" + toolName + "\" >" );
        output.Add ( "description = <\" * \">" );
        output.Add ( ">" );
        count++;
    }
    File.WriteAllLines ( @"C:\output.txt" , output.ToArray ( ) );
