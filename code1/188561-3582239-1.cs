    public static IEnumerable<Control> AllControls(this Control ctl)
    {
       List<Control> collection = new List<Control>();
       if (ctl.HasControls())
       {
           foreach (Control c in ctl.Controls)
           {
                 collection.Add(c);
                 collection = collection.Concat(c.AllControls()).ToList();
           }
       }
       return collection;
    }
