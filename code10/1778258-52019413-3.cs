    public static void Serialize<T>(T t, string filePath, bool overwrite = true)
    {
        using (var fs = new FileStream(filePath, overwrite ? FileMode.Create : FileMode.CreateNew, FileAccess.Write))
        {
            var serializer = new XmlSerializer(typeof(T));
            var ns = new XmlSerializerNamespaces();
            ns.Add("", ""); // Omits xmlns:xsi/xmlns:xsd
            try
            {
                serializer.Serialize(fs, t, ns);
            }
            catch (System.Exception)
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);
                throw;
            }
        }
    }
