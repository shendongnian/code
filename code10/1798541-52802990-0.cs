     public static async Task<Contact> MapContact(DbDataReader dataReader){
        if(await dataReader.ReadAsync() &&  dataReader.HasRows){
            Contact contact = new Contact();
            contact.Id =  dataReader.GetInt32( dataReader.GetOrdinal("Id"));
            contact.Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
            contact.EmailAddress = dataReader.GetString(dataReader.GetOrdinal("EmailAddress"));
            Company company = new Company();
            company.Id = dataReader.GetInt32(dataReader.GetOrdinal("CompanyId"));
            company.Name = dataReader.GetString(dataReader.GetOrdinal("CompanyName"));
            contact.Company = company;
            return contact;
        }
        return null;
    }
