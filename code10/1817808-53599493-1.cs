          public class DogFriend : EntityBase<int>
          {
            public int Id {get; set;} (PK)
            public int DogId {get; set;} (FK)
            public string FirstName { get; set; }
            public string LastName { get; set; }
          }
