          public class Dog : EntityBase<int>
          { 
            public int Id {get; set;} (PK)      
            public string FirstName { get; set; }
            public DogFertility DogFertility { get; set; }
            public DogGender DogGender { get; set; }
            public string Description { get; set; }
            public DateTime DoB { get; set; }      
            public DogBreed DogBreed { get; set; }
            public virtual List<DogFriend> DogFriends{ get; set; }
          }
