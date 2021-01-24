    private object box1;
    private object box2;
    private object box3;
    //The following code base could be in a button click event
    StringBuilder errorMessages = new StringBuilder();
    
    if(box1 == null)
    {
       errorMessages.AppendLine("Error 1");
    }
    if(box2 == null)
    {
       errorMessages.AppendLine("Error 2");
    }
    if(box3 == null)
    {
       errorMessages.AppendLine("Error 3");
    }
    
    if(!string.IsNullOrWhiteSpace(Convert.ToString(errorMessages)))
    {
    	MessageBox.Show(errorMessages.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
    
