    public class Person
    {
        public Person(){}
        private GPS _gps = new GPS();
        public Coords getLoc
        {
            get{
                return _gps.devise.coordinates.getLoc;
            }
        }
    }
    Person Me = new Person;
    Coords MyLocation = Me.getLoc;
