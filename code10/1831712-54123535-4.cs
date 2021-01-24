    var jsettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.Indented,
                    TypeNameHandling = TypeNameHandling.Auto,
                    TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
                string json = string.Empty;
                using (StreamReader file = new StreamReader(filename))
                {
                    json = file.ReadToEnd();
                }
                var contactroot = JsonConvert.DeserializeObject<ContactRoot>(json);
                DataSource.SimpleContacts = new List<SimpleContact>();
                foreach (var contactdto in contactroot.SerializableContacts)
                {
                    DataSource.SimpleContacts.Add(ConvertToContact(contactdto));
                }
