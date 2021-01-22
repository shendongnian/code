    string[] array = data.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);  
    System.Diagnostics.Debug.WriteLine(string.Format("Number of numbers: {0}", array.Length));  
    foreach(string str in array)  
    {  
    	System.Diagnostics.Debug.WriteLine(str);  
    }  
