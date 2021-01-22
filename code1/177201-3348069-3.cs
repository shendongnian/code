    if(!item.IsValid)
    {
        foreach(var propertyInfo in item.GetType().GetProperties())
        {
            IList<string> list = new List<string>();
            foreach (ValidationAttribute attribute in propertyInfo.GetCustomAttributes(typeof(ValidationAttribute),true))
            {
                attribute.Validate(item,propertyInfo,ref list);
            }
    
            if(list.Count > 0)
            {
                // make sure it's not ignored
                var browsable = propertyInfo.GetCustomAttributes(typeof (BrowsableAttribute), true);
                if(browsable.Count() == 0)
                {
                    dataGridView1.Rows[e.RowIndex].Cells[propertyInfo.Name].ErrorText = list[0];
                }
            }
        }
    
        e.Cancel = true;
    }
