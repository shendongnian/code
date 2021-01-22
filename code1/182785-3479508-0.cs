    public class SomeDal
    {
        public void CreateUser(User userToBeCreated)
        {
            using(connection bla bla)
            {
                // create and execute a command object filling its parameters with data from the User object
            }
        }
    }
    public class User
    {
        public string Name { get; set; }
        ...
    }
    public class SomeUI
    {
        public void HandleCreateClick(object sender, e ButtonClickEventArgs)
        {
            User userToBeCreated = new User() { Name = txtName.Text };
            SomeDal myDal = new SomeDal();
            myDal.CreateUser(userToBeCreated);
        }
    }
