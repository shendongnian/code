    public class Person{
    	public string Name{get; set;}
    	
    	private Person[] _backingStore;
    	public Person this[int index]
        {
            get{
                return _backingStore[index];
            }
            set{
                _backingStore[index] = value;
            }
        }
    }
    
    Person p = new Person();
    p[0] = new Person(){Name = "Hassan"};
    p[1] = new Person(){Name = "John Skeet"};    
