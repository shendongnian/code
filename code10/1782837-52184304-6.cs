    void Main()
    {
        var dog = new Dog();
        SaveAnimal(dog); // does not compile
    	
    	Animal<ISaveAble> generalAnimal = new Animal<ISaveAble>();
    	SaveAnimal(generalAnimal); // compiles		
    }
