    public class Dog
        {
    
            int legs;
    
            public int Legs
            {
                get { return legs; }
                set { legs = value; }
            }
            string name;
    
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            string breed;
    
            public string Breed
            {
                get { return breed; }
                set { breed = value; }
            }
    
        }
        
        public class DogBll
        {
            List<Dog> myDog;
            public DogBll()
            {
                myDog = new List<Dog>();
                myDog.Add(new Dog() { Legs = 10, Name = "mimi", Breed = "german" });
                myDog.Add(new Dog() { Legs = 4, Name = "momo", Breed = "english" });
            }
            public List<Dog> GetDogs()
            {
                return myDog;
            }
        }
