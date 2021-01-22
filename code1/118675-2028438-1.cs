            public bool FilterById(Foo obj, int id)
            {
                return obj.id == id;
            }
            public bool FilterByName(Foo obj, string name)
            {
                return obj.name == name;
            }
