    public class MyObject()
    {
        public int Id { get; private set; } // Read-only
        public string Name { get; set; }
        // This method is essentially a more descriptive constructor, using the repository pattern for seperation of Domain and Persistance
        public static MyObject GetObjectFromRepo(IRepository repo)
        {
            MyObject result = new MyObject();
            return repo.BuildObject(result, out Id);            
        }
    }
    public class MyRepo : IRepository
    {
        public MyObject BuildObject(MyObject objectShell, out int id)
        {
            string objectName;
            int objectId;
   
            // Retrieve the Name and Value properties
            objectName = "Name from Database";
            objectId = 42;
            //
            objectShell.Name = objectName;
            Console.WriteLine(objectShell.Id); // <-- 0, as it hasn't been set yet
            id = objectId; // Setting this out parameter indirectly updates the value in the resulting object
            Console.WriteLine(objectShell.Id); // <-- Should now be 42
        }
    }
