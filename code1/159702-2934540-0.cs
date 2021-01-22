    foreach (PropertyInfo PropertyItem in this.GetType().GetProperties())
    {
        if (!(PropertyItem.Name.ToString() == cust.PKName))
        {
            if (PropertyItem.Name.ToString() != "TableName")
            {
                if (SQL == null)
                {
                    SQL = PropertyItem.Name.ToString() + " = @" + PropertyItem.Name.ToString();
                }
                else
                {
                    SQL = SQL + ", " + PropertyItem.Name.ToString() + " = @" + PropertyItem.Name.ToString();
                }
             }
             else
             {
                break;
             }
        }
