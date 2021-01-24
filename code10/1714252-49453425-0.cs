    namespace ExcellentDesignedClasses
    {
        public class NewPlayerClass
        {
            public NewPlayerClass(int id, string name)
            {
                Id = id;
                Name = name;
            }
    
            public static NewPlayerClass Convert(Player player)
            {
                return new NewPlayerClass((int)player.Id, (string)player.Name);
            }
    
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
