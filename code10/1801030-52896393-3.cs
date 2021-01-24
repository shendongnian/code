    public class /* or struct */ Category
    {
        public Category( Int32 id, String name )
        {
            this.Id = id;
            this.Name = name;
        }
        public Int32 Id { get; }
        public String Name { get; }
    }
    public static Category[] GetCategories()
    {
        return new[]
        {
            new Category( 1, "A" ),
            new Category( 2, "BA" ),
            new Category( 3, "BAC" ),
        };
    }
