    public class Bird
    {
        private string name;
        private double weight = 30.5d;
        public string Name
        {
            get => name;
            set
            {
                if (value != null && value.Length > 2)
                {
                    Console.WriteLine("Bird already has a name");
                    name = value;
                }
                else if (value != null && value.Length < 3)
                {
                    Console.WriteLine("New name must be longer than two chars");
                }
                else
                {
                    name = value;
                }
            }
        }
        public void Chirp()
        {
            System.Console.WriteLine(name + " says chirp!");
        }
    }
