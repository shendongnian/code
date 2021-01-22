    using System.Xml.Linq;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    
    interface IUser
    {
        int ID
        {
            get;
            set;
        }
        string Name
        {
            get;
            set;
        }
    }
    
    class User : IUser
    {
    
        #region IUser Members
    
        public int ID
        {
            get;
            set;
        }
    
        public string Name
        {
            get;
            set;
        }
    
        #endregion
    
        public override string ToString()
        {
            return ID + ":" + Name;
        }
    
    
        public static IEnumerable<IUser> GetMatchingUsers(IEnumerable<IUser> users)
        {
            IEnumerable<IUser> localList = new List<User>
             {
                new User{ ID=4, Name="James"},
                new User{ ID=5, Name="Tom"}
    
             }.OfType<IUser>();
    
            OutputUsers(users);
            var matches = from u in users
                          join lu in localList
                              on u.ID equals lu.ID
                          select u;
            return matches;
        }
    
        public static void OutputUsers(IEnumerable<IUser> users)
        {
            Console.WriteLine("==> Start");
            foreach (IUser user in users)
            {
                Console.WriteLine("ID=" + user.ID.ToString() + ", Name=" + user.Name + ", HashCode=" + user.GetHashCode().ToString());
            }
            Console.WriteLine("<== End");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = new XDocument(
                new XElement(
                    "Users",
                    new XElement("User", new XAttribute("id", "1"), new XAttribute("name", "Jeff")),
                    new XElement("User", new XAttribute("id", "2"), new XAttribute("name", "Alastair")),
                    new XElement("User", new XAttribute("id", "3"), new XAttribute("name", "Anthony")),
                    new XElement("User", new XAttribute("id", "4"), new XAttribute("name", "James")),
                    new XElement("User", new XAttribute("id", "5"), new XAttribute("name", "Tom")),
                    new XElement("User", new XAttribute("id", "6"), new XAttribute("name", "David"))));
            IEnumerable<IUser> users = doc.Element("Users").Elements("User").Select
                (u => new User
                {
                    ID = (int)u.Attribute("id"),
                    Name = (string)u.Attribute("name")
                }
                ).OfType<IUser>();       //still a query, objects have not been materialized
    
    
            User.OutputUsers(users);
            var matches = User.GetMatchingUsers(users);
            User.OutputUsers(users);
            var excludes = users.Except(matches);    // excludes should contain 6 users but here it contains 8 users
    
        }
    }
