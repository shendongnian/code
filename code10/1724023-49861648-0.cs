    //TDoughArts tells you what type of arguments the factory needs in order to make dough.
    public interface IPizzaIngredientFactory<TDoughArgs> where TDoughArgs : IDoughArgs;      
    {
        //....
        IDough CreateDough(TDoughArgs doughArgs);
        //....
    }
    public interface IDoughArgs
    {
        
    }
    public class NYPizzaDoughArgs : IDoughArgs
    {
        public enum DoughTypes
        {
            Thin = 0,
            Thick = 1
        }
        public DoughTypes DoughType { get; set; }
    }
    public class NYPizzaIngredientFactory : IPizzaIngredientFactory<NYPizzaDoughArgs>
    {
        //....
        public IDough CreateDough(NYPizzaDoughArgs doughArgs)
        {
            //Make the right dough based on args here
            if(doughArgs.DoughType == DoughTypes.Thin)
                //...
        }
        //....
    }
