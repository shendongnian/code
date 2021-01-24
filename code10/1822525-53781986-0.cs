     private static string GetReflectedLandlineValue(object person)
     {
          IEnumerable<object> contactList = (IEnumerable<object>)person.GetType().GetProperty("ContactInfo")?.GetValue(person);
          return (string) contactList.First().GetType().GetProperty("Landline")?.GetValue(contactList.First());
     }
