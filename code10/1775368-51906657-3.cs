    public ContactInfo GetSingleRecord(string Name)
    {
      return connection.Table<Student>().FirstOrDefault(i => i.StudentName == Name);
    }
    
    public void UpdateContact(Student obj)
    {
    	connection.Update(obj);
    }
