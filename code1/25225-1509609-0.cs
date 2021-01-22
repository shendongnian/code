    if (string.IsNullOrEmpty(line))
    {
    	//skip empty lines
    }
    else switch (line.Substring(0,1))
    {
    	case "1":
    		Console.WriteLine(line);
    		break;
    	case "9":
    		Console.WriteLine(line);
    		break;
    	default:
    		break;
    }
