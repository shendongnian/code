    foreach (PropertyInfo PropertyItem in this.GetType().GetProperties())
        {
            string strValue = PropertyItem.Name == DbNull.Value ? String.Empty : PropertyItem.Name.ToString();
            PropertyItem.SetValue(this, objDataTable.Rows[0][strValue], null);
        }
