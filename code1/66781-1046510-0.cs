    // This requires the following using statements in the file:
    // using System.Resources;
    // using System.Collections;
    
    ResourceManager rm = new ResourceManager(typeof(Images));
    using (ResourceSet rs = rm.GetResourceSet(Thread.CurrentThread.CurrentUICulture, true, true))
    {
        IDictionaryEnumerator resourceEnumerator = rs.GetEnumerator();
        while (resourceEnumerator.MoveNext())
        {
            if (resourceEnumerator.Value is Image)
            {
                Console.WriteLine(resourceEnumerator.Key);
            }
        }
    }
