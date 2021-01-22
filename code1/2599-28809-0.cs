    private List<T> FindControlsByType<T>(ControlCollection controls )
    {
        List<T> foundList = new List<T>();
        foreach (Control ctrl in this.Page.Controls)
        {
            if (ctrl as T != null )
            {
                // Do whatever with interface
                foundList.Add(ctrl as T);
            }
            // Check if the Control has Child Controls and use Recursion
            // to keep checking them
            if (ctrl.HasControls())
            {
                // Call Function to 
                List<T> childList = FindControlsByType<T>( ctrl.Controls );
                foundList.AddRange( childList );
            }
        }
        return foundList;
    }
    // Pass it this way
    FindControlsByType<IYourInterface>( Page.Controls );
