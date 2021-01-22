    // Add new partial class to extend functionality
    public partial class User {
      // Add additional constructor
      public User(int id) {
        ID = id;
      }
      // Add static method to initialize new object
      public User GetNewUser() {
        // functionality
        User user = new User();
        user.Name = "NewName";
        return user;
      }
    }
