     //of course u can use your own base class instead of interface. 
    interface IPetDescriptor
    {
       //here u can place some additional type information, if u need. Tags or genetic code, or maybe some story about this type
        Pet CreatePet();//Maybe u need some aditional createInformation?
    }
    class DogDescriptor:IPetDescriptor
    {
       public Pet CreatePet(){ return new Dog();}
    }
    class CatDescriptor:IPetDescriptor
    {
       public Pet CreatePet(){ return new Cat();}
    }
     class Pet
     {
        public Pet static Pet.Factory(IPetDescriptor descriptor)
        {
           //Place for additional initialization, if u need...
           //we don't care about pet type. Thats good.
           return descriptor.CreatePet(); 
         }
         .... 
     }
