    public class Dog {
       string Name;
       public Dog(string name) { Name = name ; }
    }
    public class Cat {
       string Name;
       public Cat(string name) { Name = name ; }
    }
    public class test
	{
	    public Book MyBook ;
	    public SheetTyped<Dog> AllMyDog ;
	    public SheetTyped<Cat> AllMycat ;
		public void MyTest()
		{
            Dog[] InitDogs = { new Dog("Fuffy")
                             , new Dog("Puffy")
                             , new Dog("Alex") };
            Cat[] InitCats = { new Cat("Romeo")
                             , new Cat("July")
                             , new Cat("Briciola") };
            List<Dog> MyDogList = new List<Dog>(InitDogs);
            List<Cat> MyCatList = new List<Cat>(InitCats);
  
	        AllMyDog  = new SheetTyped<Dog>( "My dogs", MyDogList ) ;
	        AllMycat  = new SheetTyped<Cat>( "My cats", MyCatList ) ;
	        MyBook    = new Book() ;
	        MyBook.Sheets = new List<Sheet>(2);
	        MyBook.Sheets[0] = AllMyDog  ;
	        MyBook.Sheets[1] = AllMycat  ;
		}
	}
