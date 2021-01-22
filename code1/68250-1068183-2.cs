    string lastItem = list[list.Count - 1];
    foreach (string item in list) {
    	if (!item.ReferenceEquals(lastItem))
    		Console.WriteLine("Looping: " + item);
    	else	Console.Writeline("Lastone: " + item);
    }
