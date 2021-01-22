    public static void Append(this System.Windows.Forms.Control.ControlCollection collection, System.Windows.Forms.Control.ControlCollection newCollection)
    {
        Control[] newControl = new Control[newCollection.Count];
        newCollection.CopyTo(newControl, 0);
        collection.AddRange(newControl);
    }
