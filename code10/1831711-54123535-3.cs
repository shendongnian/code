    var contactroot = new ContactRoot
                {
                    SimpleContacts = DataSource.SimpleContacts,
                    SerializableContacts = new List<ContactDto>()
                };
                foreach (var simplecontact in contactroot.SimpleContacts)
                {
                    contactroot.SerializableContacts.Add(ConvertToDto(simplecontact));
                }
                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                var filename = Path.Combine(desktop, "WBAddon.json");
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
                using (StreamWriter file = File.CreateText(filename))
                {
                    var serializer = new JsonSerializer()
                    {
                        Formatting = Formatting.Indented,
                        TypeNameHandling = TypeNameHandling.Auto,
                        TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    };
                    await Task.Run(() => serializer.Serialize(file, contactroot));
                }
