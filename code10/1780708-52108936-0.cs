    [Table("Books")]
    public class Book
    {
        public int ID { get; set; }
        public int Genre { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public Date PublishDate { get; set; }
    }
    [Table("Genres")]
    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    [Table("Users")]
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    [Table("UserGenrePreferences")]
    public class UserGenrePreference
    {
        public int User { get; set; }
        public int Genre { get; set; }
    }
