    public static IEnumerable<Control> AllControls(this Control ctl)
    {
       IEnumerable<Control> collection = Emumerable.Empty<Control>();
       if (ctl.HasControls())
       {
           foreach (Control c in ctl.Controls)
           {
                 collection.Add(c);
                 collection = collection.Concat(c.AllControls());
           }
       }
       return collection;
    }
