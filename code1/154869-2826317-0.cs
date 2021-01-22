    public List<Users> GetUsersList()
    {
        List<Users> myList = new List<Users>();
        string[] names = FunNames();
        string[] ages = FunAge();
        string[] genders = Fungender();
        string[] countries = Funcountry();
        
        for (int i = 0; i < names.Length; i++)
        {
            Users user = new Users();
            user.Name = names[i];
            user.Age = names[i];
            user.Gender = names[i];
            user.Country = names[i];
            myList.Add(user);
        }
        return myList();
    }
