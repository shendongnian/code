    public struct Tombstone
    {
      public Slab mainSlab;
      public Slab basing;
      public bool hasBasing => basing.sizeM != null;
      //more...
    }
