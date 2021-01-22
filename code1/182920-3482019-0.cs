      private void AddValues(object values)
        {
            if (values != null)
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(values))
                {
                    object obj2 = descriptor.GetValue(values);
                    this.Add(descriptor.Name, obj2);
                }
            }
        }
