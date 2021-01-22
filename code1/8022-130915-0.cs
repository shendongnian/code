    public List<string> ValidUsers(List<User> users) {
      List<string> names = new List<string>();
      foreach(User user in users) {
        if(user.Valid) {
          names.Add(user.Name);
        }
      }
      return names;
    }
