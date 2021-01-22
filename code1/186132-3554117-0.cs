    private void DoSomethingWithCollection(ICollection collection)
    // private void DoSomethingWithCollection(IEnumerable collection)
    {
        NameValueCollection nv;
        KeyValueConfigurationCollection kvc;
        if ((nv = collection as NameValueCollection) != null)
        {
            // do stuff directly or call iterate and call 3rd method
        }
        else if ((kvc = collection as KeyValueConfigurationCollection) != null)
        {
            // do stuff directly or call iterate and call 3rd method
        }
    }
