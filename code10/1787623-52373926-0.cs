    /// <summary>
    /// Returns true if a color is selected. Otherwise, it returns false and displays an error message.
    /// </summary>
    public override bool IsValid()
    {
         if ((string)Value != "")
         {
             return true;
         }
         else
         {
             // Sets the form control validation error message
             this.ValidationError = "Please choose a color.";
             return false;
         }
    }
