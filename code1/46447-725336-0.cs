    try
    {
     using (DialogForm frm = new DialogForm())   
     {     
           DialogResult r = frm.ShowDialog();
           label1.Text = r.ToString();  
     }
    }
    catch (Exception ex)
    {
        label1.Text = ex.Message;
    }
    catch
    {
        label1.Text = "Unknown Exception";
    }
