You can retrieve the path of an isolated storage file on disk by accessing a private field of the IsolatedStorageFileStream class, by using reflection. Here's an example:
// Create a file in isolated storage.
IsolatedStorageFile store = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
IsolatedStorageFileStream stream = new IsolatedStorageFileStream("test.txt", FileMode.Create, store);
StreamWriter writer = new StreamWriter(stream);
writer.WriteLine("Hello");
writer.Close();
stream.Close();
// Retrieve the actual path of the file using reflection.
string path = stream.GetType().GetField("m_FullPath", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(stream).ToString();
