    using System.Collections;
    using System.Globalization;
    using System.Resources;
    ...
    ResourceSet resourceSet = MyResourceClass.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
    foreach (DictionaryEntry entry in resourceSet)
    {
        string resourceKey = entry.Key.ToString();
        object resource = entry.Value;
    }
