    public string SomeProperty
    {
        get 
        { 
            string value = null;
            if(BindingContext[dataGridView1.DataSource].Current !=null)
            {  
               var r = ((DataRowView)BindingContext[dataGridView1.DataSource].Current).Row;    
               value = r.Field<string>("SomeDataColumn");
            }
            return value;
        }
    }
