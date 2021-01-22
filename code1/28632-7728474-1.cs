    internal static class AppSettings
    {
        internal static void Save(object src, string targ, string fileName)
        {
            Dictionary<string, object> items = new Dictionary<string, object>();
            Type type = src.GetType();
            string[] paramList = targ.Split(new char[] { ',' });
            foreach (string paramName in paramList)
                items.Add(paramName, type.GetProperty(paramName.Trim()).GetValue(src, null));
            try
            {
                // GetUserStoreForApplication doesn't work - can't identify.
                // application unless published by ClickOnce or Silverlight
                IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(fileName, FileMode.Create, storage))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write((new JavaScriptSerializer()).Serialize(items));
                }
            }
            catch (Exception) { }   // If fails - just don't use preferences
        }
        internal static void Load(object tar, string fileName)
        {
            Dictionary<string, object> items = new Dictionary<string, object>();
            Type type = tar.GetType();
            try
            {
                // GetUserStoreForApplication doesn't work - can't identify
                // application unless published by ClickOnce or Silverlight
                IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly();
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(fileName, FileMode.Open, storage))
                using (StreamReader reader = new StreamReader(stream))
                {
                    items = (new JavaScriptSerializer()).Deserialize<Dictionary<string, object>>(reader.ReadToEnd());
                }
            }
            catch (Exception) { return; }   // If fails - just don't use preferences.
            foreach (KeyValuePair<string, object> obj in items)
            {
                try
                {
                    tar.GetType().GetProperty(obj.Key).SetValue(tar, obj.Value, null);
                }
                catch (Exception) { }
            }
        }
    }
