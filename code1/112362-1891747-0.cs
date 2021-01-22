    public abstract class User
    {
        protected String _name;
    }
    public sealed class PublicUser : User
    {
        public String Name
        {
            get{ return this._name; }
        }
    }
    public class PrivateUser : User
    {
        public String Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
    }
