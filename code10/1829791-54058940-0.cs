    public class Person : IEquatable<Person> 
    {
        public int Age { get; private set;}
        public string Name { get; private set;}
        public bool override Equals(Person other){
            return other.Age == Age && other.Name.Equals(Name);
        }
        public override int GetHashCode(){
            return Age.GetHashCode() ^ Name.GetHashCode();
        }
    }
    private IEnumerable<Person> MakeUniqueList(IEnumerable<Person> input){
        return new HashSet<Person>(input);
    }
