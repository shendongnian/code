            using (var db = new LiteDatabase(filePath))
            {
                Tools = db.GetCollection<ExternalTools>("externalTools");
                if (Tools.Count() == 0)
                {
                    CreateToolList();
                    // Index document using document Name property
                    Tools.EnsureIndex(x => x.Name);
                }
                Debug.WriteLine(Tools.Count());
                var temp = Tools.FindAll(); // null error
                var test = Tools.FindById(1); // another null error
                Debug.WriteLine(test.Name); //
            }
