    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    [XmlRoot("user_list")]
    public class UserList
    {
        public UserList() {Items = new List<User>();}
        [XmlElement("user")]
        public List<User> Items {get;set;}
    }
    public class User
    {
        [XmlElement("id")]
        public Int32 Id { get; set; }
    
        [XmlElement("name")]
        public String Name { get; set; }
    }
    
    static class Program
    {
        static void Main()
        {
            XmlSerializer ser= new XmlSerializer(typeof(UserList));
            UserList list = new UserList();
            list.Items.Add(new User { Id = 1, Name = "abc"});
            list.Items.Add(new User { Id = 2, Name = "def"});
            list.Items.Add(new User { Id = 3, Name = "ghi"});
            ser.Serialize(Console.Out, list);
        }
    }
