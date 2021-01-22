    foreach (DataRow dr in appearances) {
       string type = dr["Type"].ToString();
       PropertyInfo propertyForType = grid.AppearancePrint.GetType().GetProperty(type);
       object objectForProperty = propertyForType.GetValue(grid.AppearancePrint, null);
       
       PropertyInfo propertyForBackColor = objectForProperty.GetType().GetProperty("BackColor");
       PropertyInfo propertyForBackColor2 = objectForProperty.GetType().GetProperty("BackColor2");
       propertyForBackColor.SetValue(objectForProperty, Color.FromName(dr["BackColor"].ToString()), null);
       propertyForBackColor2.SetValue(objectForProperty, Color.FromName(dr["BackColor2"].ToString()), null);
    }
