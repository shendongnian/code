        public class Dog : EntityBase<int>
    {        
        public string FirstName { get; set; }
        public DogFertility DogFertility { get; set; }
        public DogGender DogGender { get; set; }
        public string Description { get; set; }
        public DateTime DoB { get; set; }      
        public DogBreed DogBreed { get; set; }        
        
        public virtual List<UserDog> UserDogs { get; set; }
        public virtual List<DogFriend> DogFriends{ get; set; }       
        public Dog()
        {
            UserDogs = new List<UserDog>();
            DogFriends = new List<DogFriend>();            
        }             
    }
         public class DogFriend : EntityBase<int>
    {
       
        
        public int DogId { get; set; }                              //for foreign key
        [NotMapped]
        public string DogFriendSearchInput { get; set; }
        [NotMapped]
        public string DogFriendFirstName { get; set; }
        [NotMapped]
        public string DogFriendProfilePic { get; set; }
        public int DogFriendId { get; set; } 
        [NotMapped]
        public DogBreed DogBreed { get; set; }
        public Dog Dog { get; set; }
        
        public DogFriend()
        {
            
        }
    }
          public class AddDogFriendViewModel
    {
        public string DogFriendSearchInput { get; set; }
        public Domain.Model.Dog Dog { get; set; }
        public string DogFriendFirstName { get; set; }
        public int DogFriendId { get; set; }
        public int DogId { get; set; }
        public string ReturnUrl { get; set; }       
        public DogFriend DogFriend { get; set; }              
        public AddDogFriendViewModel()
        {
            
        }
    }
