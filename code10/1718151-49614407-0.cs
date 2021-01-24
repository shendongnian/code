    public class Dog : Animal 
    {
        public void Woof()
        { }
        public int ID { get; set; }  //you would have to make this up
        public Dog()
        { }
        public Dog (Animal animal) 
        {
            //now the dog is nothing more than an animal
        }
    }
    
    Dog dog = new Dog(animal);
