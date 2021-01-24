    public class FakeData
    {
        public List<User> Users { get; private set; }
        public List<Project> Projects { get; private set; }
        public FakeData()
        {
            Users = new List<User>
            {
                //Some Data here
            };
            Projects = new List<Project>
            {
                //Some data here
            };
        }
    }
