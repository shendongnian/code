    public class Customer
    {
      public string Name { get; set; }
      public List<Contact> Contacts { get; set; }
    }
    
    public class Contact
    {
      public string Name { get; set; }
      public List<Email> EmailAddresses {get; set;}
    }
    
    public class Email
    {
      public string EmailAddress {get; set;}
    }
        private void TrimWhitespace(object instance)
        {
            if (instance != null)
            {
                var props = instance.GetType()
                        .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    // Ignore indexers
                        .Where(prop => prop.GetIndexParameters().Length == 0)
                    // Must be both readable and writable
                        .Where(prop => prop.CanWrite && prop.CanRead);
                foreach (PropertyInfo prop in props)
                {
                    if (instance is IEnumerable)
                    {
                        foreach (var item in (IEnumerable)instance)
                        {
                            TrimWhitespace(item);
                        }
                    }
                    else if (prop.GetValue(instance, null) is string)
                    {
                        string value = (string)prop.GetValue(instance, null);
                        if (value != null)
                        {
                            value = value.Trim();
                            prop.SetValue(instance, value, null);
                        }
                    }
                    else 
                        TrimWhitespace(prop.GetValue(instance, null));
                }
            }
        }
