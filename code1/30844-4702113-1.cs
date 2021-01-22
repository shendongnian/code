    public abstract class Animal
    {
        //some code common to all animals
        public TAnimal OpenTheEyes<TAnimal>() where TAnimal : Animal
        {
            //Some code to flutter one's eyelashes and then open wide
            return (TAnimal)this; //returning a self reference to allow method chaining
        }
    }
