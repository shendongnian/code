    public static Type GetType(DatabaseField field)
    {
      DataBaseRecordInfo dbri = new DataBaseRecordInfo();
    
      switch (field)
      {
        case DatabaseField.NumID1:
          return dbri.NumID1.GetType(); 
        case DatabaseField.NumID2:
          return dbri.NumID2.GetType(); 
        case DatabaseField.NumID3:
         return dbri.NumID3.GetType(); 
        default:
          return typeof(int);
      }
    }
I know you said without ever having to create an instance of DataBaseRecordInfo but I'm assuming you meant an instance outside of the static method. No one ever sees this instance.
