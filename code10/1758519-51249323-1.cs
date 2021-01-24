        public void ConfigureServices(IServiceCollection services)
        {
            IList<Assembly> components = new List<Assembly>();
            foreach (string file in Directory.EnumerateFiles(@"C:\Users\userName\source\repos\core2.1test\core2.1test\nuqkgs\", "*.nupkg", SearchOption.AllDirectories))
            {
                using (ZipArchive nuget = ZipFile.Open(file, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in nuget.Entries)
                    {
                        if (entry.Name.Contains(".dll"))
                        {
                            string createPathSource = @"C:\Users\userName\source\repos\core2.1test\core2.1test\nuqkgs\"+ entry.Name;
                            using (BinaryReader reader = new BinaryReader(entry.Open()))
                            {
                                // Step 1
                                using (FileStream fsNew = new FileStream(createPathSource, FileMode.Create, FileAccess.Write))
                                {
                                    fsNew.Write(reader.ReadBytes((int)entry.Length), 0, (int)entry.Length);
                                }
                                // Step 2
                                using (FileStream readStream = File.Open(createPathSource, FileMode.Open))
                                {
                                    var assempbly = AssemblyLoadContext.Default.LoadFromStream(readStream);
                                    components.Add(assempbly);
                                }
                            }
                        }
                    }
                }
            }
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc()
              .ConfigureApplicationPartManager(apm =>
              {
                  foreach (var c in components)
                  {
                      var part = new AssemblyPart(c);
                      apm.ApplicationParts.Add(part);
                  }
              });
        }
