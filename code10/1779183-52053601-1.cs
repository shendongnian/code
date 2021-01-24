    public class Person
    {
        private string _name;
        private void SetInitialized([CallerMemberName]string propertyName = "")
        {
            // update a dictionary
        }
        public string Name { get => _name; set { _name = value; SetInitialized(); } }
    }
