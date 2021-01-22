    public String TrimIfNotNull(this string item)
    {
       if(String.IsNullOrEmpty(item))
         return item;
       else
        return item.Trim();
    }
