    public ContactDto ConvertToDto(SimpleContact simpleContact)
        {
            var contactdto = new ContactDto();
            foreach (PropertyInfo prop in simpleContact.GetType().GetProperties().Where(t => t.DeclaringType == typeof(SimpleContact)))
            {
                var value = prop.GetValue(simpleContact);
                if (value != null)
                {
                    var prop2 = contactdto.GetType().GetProperty(prop.Name);
                    prop2.SetValue(contactdto, value);
                }
            }
            return contactdto;
        }
    public SimpleContact ConvertToContact(ContactDto contactDto)
        {
            var simplecontact = new SimpleContact();
            foreach (PropertyInfo prop in contactDto.GetType().GetProperties())
            {
                var value = prop.GetValue(contactDto);
                if (value != null)
                {
                    var prop2 = simplecontact.GetType().GetProperty(prop.Name);
                    prop2.SetValue(simplecontact, value);
                }
            }
            return simplecontact;
        }
