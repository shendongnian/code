    void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            //Show error message
            lblError.Text = "There is a problem"; 
  
            //Set the exception handled property so it doesn't bubble-up
            e.ExceptionHandled = true;
        }
    }
