    public struct LolCatId {
      public int Id { get; }
      public LolCatId(int id) {
        Id = id;
      }
      public override int GetHashCode() => Id;
      public override bool Equals(object obj) => 
        obj is LolCatId other ? other.Id == Id : false;
    }
