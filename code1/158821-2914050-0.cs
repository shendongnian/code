    public void Enumerate(string displayText)
    {
         Column column = this.Columns.FirstOrDefault(item => item.DisplayText == displayText);
         if (column != null)
         {
              foreach (T key in DataSource)
              {
                   object value = column.Rowdata(key);
                   // Do something with your value here.
              }
         }
         else
         {
             throw new ArgumentException("DisplayText not found in Columns.", "displayText");
         }
    }
