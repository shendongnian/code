    int amount;
    if(int32.TryParse((string)value,out amount)
    {
       if(amount>=35)
        {
            return true;
        }
        else
        {
          return false;
        }
    }
    else
    {
      return false;
    }
