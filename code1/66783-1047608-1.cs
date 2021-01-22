     public static List<string> GetImageList()
                {
                    System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
                    System.Globalization.CultureInfo culture = Thread.CurrentThread.CurrentCulture;
                    string resourceName = asm.GetName().Name + ".g";
                    System.Resources.ResourceManager rm = new System.Resources.ResourceManager(resourceName, asm);
                    System.Resources.ResourceSet resourceSet = rm.GetResourceSet(culture, true, true);
                    List<string> resources = new List<string>();
                    foreach (DictionaryEntry resource in resourceSet)
                    {
                        resources.Add((string)resource.Key);
                    }
                    rm.ReleaseAllResources();
                    return resources;
                }
