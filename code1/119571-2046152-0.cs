    public interface IUser
    {
        List<Item> Items { get; set; }
        List<Tag> Tags { get; set; }
    }
    public interface IItem
    {
         List<Tag> Tags { get; set; }
    }
    public interface ITag
    {
         List<Item> Items { get; set;}
    }
