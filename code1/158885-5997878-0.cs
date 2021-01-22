    protected void obdsList_Selected(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.ReturnValue != null)
        {
            if (e.ReturnValue.GetType() == typeof(int))
            {
                //e.ReturnValue is the SelectCountMethod value
            }                
        }
    }
