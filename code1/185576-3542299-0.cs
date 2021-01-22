    private class MyRecord : IEquatable<MyRecord>
    {
      public int ID;
      public string Name;
      public string Country;
      public DateTime DateCreated;
      public bool Equals(MyRecord other)
      {
        return Name.Equals(other.Name);
      }
      public override bool Equals(object obj)
      {
        return obj is MyRecord && Equals((MyRecord)obj);
      }
      public override int GetHashCode()
      {
        return Name.GetHashCode();
      }
    }
    /*...*/
    var items = (from i in user select new MyRecord {i.ID, i.Name, i.Country, i.DateRecord}).Distinct();
