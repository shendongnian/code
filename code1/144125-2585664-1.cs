    public void DisplayObject(Label label, Object someObject)
    {
        if (someObject == null)
        {
            label.Text = ""; // or String.Empty, if you're one of *those* people
        }
        else
        {
            label.Text = someObject.ToString();
        }
    }
