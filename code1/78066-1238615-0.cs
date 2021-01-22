    public abstract class Parent
    {
        public void AddUser()
        {
            // Preparation goes here
            AddUserImpl();
            // Clean-up goes here
        }
        protected abstract void AddUserImpl();
    }
    public class Child
    {
        protected override void AddUserImpl()
        {
            // Do stuff here
        }
    }
