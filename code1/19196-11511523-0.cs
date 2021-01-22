    try
    {
    	Console.Write(wsReader.GetDouble(j).ToString());
    }
    catch	//Lame unfixable bug
    {
    	Console.Write(wsReader.GetString(j));
    }
</Code>
