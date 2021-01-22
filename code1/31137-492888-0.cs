            public Assign(A a)
            {
                foreach (var prop in typeof(A).GetProperties())
                {
                    this.GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(a, null),null);
                }
            }
