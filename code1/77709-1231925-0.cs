    public static string LoadResource(string name)
            {
                Type thisType = MethodBase.GetCurrentMethod().DeclaringType;
                string fullName = thisType.Namespace + "." + name + ".xml";
                using (Stream stream = thisType.Module.Assembly.GetManifestResourceStream(fullName))
                {
                    if(stream==null)
                    {
                        throw new ArgumentException("Resource "+name+" not found.");
                    }
                    StreamReader sr = new StreamReader(stream);
                    return sr.ReadToEnd();
                }
            }
