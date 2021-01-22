    using System.IO;
    using System.IO.IsolatedStorage;
    ...
    IsolatedStorageFile appScope = IsolatedStorageFile.GetUserStoreForApplication();    
    using(IsolatedStorageFileStream fs = new IsolatedStorageFileStream("data.dat", FileMode.OpenOrCreate, appScope))
    {
    ...
