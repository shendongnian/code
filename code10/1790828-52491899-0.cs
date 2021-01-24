    foreach(var item in splitInput)
    {
       if(item.Length != 4 || !int.TryParse(item, out number))
       {
            isValid = false;
            break;
       }
    }
