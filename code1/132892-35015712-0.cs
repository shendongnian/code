            public static string Serialize(T options, string path)
            {
                var xml = "";
                try
                {
                    File.Delete(path);
                }
                catch (Exception)
                {
                }
                try
                {
                    using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    {
                        var bf = new BinaryFormatter();
                        
                        bf.Serialize(fs, options);
                    }
                    
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                return xml;
                
            }
            public static T Deserialize(string path)
            {
                T filteroptions;
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var bf = new BinaryFormatter();
                    filteroptions = (T)bf.Deserialize(fs);
                }
                return filteroptions;
            }
        }
