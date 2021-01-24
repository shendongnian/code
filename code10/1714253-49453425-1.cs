    namespace ExcellentDesignedClasses
    {
        public class NewPlayerClass
        {
            public NewPlayerClass(int id, string name)
            {
                Id = id;
                Name = name;
            }
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
    
    namespace ExcellentDesignedClasses.Extensions
    {
        public static class Extensions
        {
            public static NewPlayerClass ConvertToNew(this Player player)
            {
                return new NewPlayerClass((int)player.Id, (string)player.Name);
            }
        }
    }
    
    namespace MyProgram
    {
        using ExcellentDesignedClasses.Extensions;
        public class Main
        {
            public void DoSomething()
            {
                var oldClassStructure = new Player();
                var newClassStructure = oldClassStructure.ConvertToNew();
            }
        }
    }
