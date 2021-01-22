    public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
    {
      var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                   select new { ID = (int)Enum.Parse(typeof(TEnum),e.ToString())
                             , Name = e.ToString() };
    
      return new SelectList(values, "Id", "Name", enumObj);
    }
