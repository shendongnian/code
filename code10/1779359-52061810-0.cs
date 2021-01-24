            DataRowView dataRowView = (DataRowView)bindingSource.Current;
            if (dataRowView.IsNew)
            {
                dataRowView[2] = NewValue; // change values 
                // but why here I cannot get the column by name like dataRowView["ID"] it returns DbNull 
            }
            BindingSource.EndEdit();
