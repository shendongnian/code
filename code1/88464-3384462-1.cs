    ContactService.cs
    
    public  ICollection<Contact> FindContacts(string name)
    {
        return FindContacts(name, null)
    }
    
    public ICollection<Contact> FindContacts(string name, int? year)
    {
       IQueryable<Contact> query = _contactRepository.GetContacts();
       
       if (!string.IsNullOrEmpty(name))
       {
           query = from q in query
                   where q.FirstName.StartsWith(name)
                   select q;
       }
    
       if (int.HasValue)
       {
           query = from q in query
                   where q.Birthday.Year <= year.Value
                   select q);
        }
    
        return (from q in query
                select q).ToList();
    }
