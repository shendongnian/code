    public class Car
    {
        public string Description { get; set; }
        public long Id { get; set; }
        // Consider any other car whose Id is the same as this car to be equal
        public override bool Equals(object obj)
        {
            var other = obj as Car;
            return other?.Id == Id; // optionally add: && other.Description == Description;
        }
    }
