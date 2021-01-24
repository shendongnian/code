    public class Generic<Att> where Att : System.Attribute
    {
        [Att] //Error: 'Att' is not an attribute class
        public float number;
    }
