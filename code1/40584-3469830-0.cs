    usr = result.GetDirectoryEntry();
    foreach (string strProperty in usr.Properties.PropertyNames)
    {
       Console.WriteLine("{0}:{1}" ,strProperty, usr.Properties[strProperty].Value);
    }
