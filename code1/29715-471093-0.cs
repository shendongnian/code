            public DecoratedModel(Model m)
            {
                foreach (var prop in typeof(Model).GetProperties())
                {
                    this.GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(m, null),null);
                }
            }
