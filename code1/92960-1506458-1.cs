     var dc = new DropTextBoxColumn();
            dc.Name = "FieldName";
            dc.DataPropertyName = "FieldName";
            dc.DropDownStyle = ComboBoxStyle.DropDownList;
            var items = dc.Items = new string[]{ "one", "two", "three" };
            items.Insert(0, "<None>");
           
            dc.Items = items;
            
            DirectGrid.Columns.Insert(1,dc);
