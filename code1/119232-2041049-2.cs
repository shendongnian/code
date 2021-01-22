    using System.Collections;
    using System.Globalization;
    using System.Resources;
    ...
            ResourceManager MyResourceClass = new ResourceManager(typeof(Resources /* Reference to your resources class -- may be named differently in your case */));
    ResourceSet resourceSet = MyResourceClass.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
    foreach (DictionaryEntry entry in resourceSet)
    {
        string resourceKey = entry.Key.ToString();
        object resource = entry.Value;
    }
