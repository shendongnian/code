      class MyObject
      {
        public MyObject()
        {
          ListAnotherObjectContainingIDAndString = new List<AnotherObjectContainingIDAndString>();
        }
        int SomeID { get; set; }
        string SomeName { get; set; }
        List<AnotherObjectContainingIDAndString> ListAnotherObjectContainingIDAndString { get; set; }
      }
