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
    
     MessageBox.Show(errorMessages.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
