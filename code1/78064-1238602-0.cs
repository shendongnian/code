    public abstract class Parent {
        public void AddUser(User user) {
            // Do parent stuff
            AddUserImpl(user);
            // More parent stuff
        }
    
        protected abstract void AddUserImpl(User user);
    }
    
    public class Child {
        protected override void AddUserImpl(User user)
        {
            // Do child stuff
        }
    }
