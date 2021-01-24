    public void CallFactory(Animal animal)
    {
         var a = AnimalDTO.Create(animal);
        Factory(a);
    }
    public void Factory(AnimalDTO animal)
    {
        animal.Switch(
            isDog: (country) => {
                // here you can be sure that the animal is dog
                // you can use country variable
                Console.Writeline($"It is a dog! from country {country}");
            },
            isCat: (size) => {
               // it is a cat
               Console.Writeline($"it is a cat of size {size}");
            });
    }
    
