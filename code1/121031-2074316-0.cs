    class TypeOne
    {
        int _integer = 0;
    }
    class TypeTwo
    {
        int _integer = 3;
    }
    class TypeThree
    {
    }
    class SoftDrink<T>
    {
        public SoftDrink()
        {
            if (typeof(T) != typeof(TypeOne) && typeof(T) != typeof(TypeTwo))
            {
                throw (new Exception("Sorry, but T must be TypeOne or TypeTwo"));
            }
        }
    }
    //this works:
    SoftDrink<TypeOne> t1 = new SoftDrink<TypeThree>();    
    //throws an exception:
    SoftDrink<TypeThree> t3 = new SoftDrink<TypeThree>();
