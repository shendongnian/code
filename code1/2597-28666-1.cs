    private List<Control> FindControlsByType(ControlCollection controls, Type typeToFind)
    {
        List<Control> foundList = new List<Control>();
    
        foreach (Control ctrl in this.Page.Controls)
        {
            if (ctrl.GetType() == typeToFind)
            {
                // Do whatever with interface
                foundList.Add(ctrl);
            }
    
            // Check if the Control has Child Controls and use Recursion
            // to keep checking them
            if (ctrl.HasControls())
            {
                // Call Function to 
                List<Control> childList = FindControlsByType(ctrl.Controls, typeToFind);
    
                foundList.AddRange(childList);
            }
        }
    
        return foundList;
    }
    
    // Pass it this way
    FindControlsByType(Page.Controls, typeof(IYourInterface));
