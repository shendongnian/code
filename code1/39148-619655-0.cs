    Dictionary<string, int> ssnTable = new Dictionary<string, int>();
    
    foreach (Person person in persons)
    {
       try
       {
          int count = ssnTable[person.SSN];
          count++;
          ssnTable[person.SSN] = count;
       }
       catch(Exception ex)
       {
           ssnTable.Add(person.SSN, 1);
       }
    }
    
    // traverse ssnTable here and remove items where value of entry (item count) > 1
