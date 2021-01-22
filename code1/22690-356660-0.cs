    string originalStr = @"OU=James\, Brown,OU=Test,DC=Internal,DC=Net";
    string replacedStr = originalStr.Replace("\,", "&#44;");
    
    string name = replacedStr.Substring(0, replacedStr.IndexOf(","));
    Console.WriteLine(name.Replace("&#44;", ","));
