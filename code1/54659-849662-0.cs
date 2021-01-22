    ResourceManager rm = Properties.Resources.ResourceManager;
    ResourceSet rs = rm.GetResourceSet(new CultureInfo("en-US"), true, true);
    if (rs != null)
    {
       IDictionaryEnumerator de = rs.GetEnumerator();
       while (de.MoveNext() == true)
       {
          if (de.Entry.Value is Image)
          {
             Bitmap bitMap = de.Entry.Value as Bitmap;
          }
       }
    }
