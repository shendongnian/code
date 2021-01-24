    using System;
    namespace Question_Answer_Console_App
    {
        class Program
        {
            static void Main(string[] args)
            {
                Drink drink = new Espresso() { Description = "Expresso" };
                Console.WriteLine(drink.Description);
    
                drink = new SecretIngredient(drink);
                Console.WriteLine(drink.Description);
    
                drink = new Ice(drink);
                Console.WriteLine(drink.Description);
    
                Console.ReadKey();
            }
            //OUTPUTS
            //Expresso
            //Expresso with SecretIngredient
            //Expresso with SecretIngredient with Ice
        }
    
        public class Drink
        {
            public virtual string Description { get; set; }
        }
    
        public class Espresso : Drink { }
    
        public abstract class DrinkDecorator : Drink
        {
            protected Drink drink;
            protected DrinkDecorator(Drink drink) => this.drink = drink;
            public override string Description => drink.Description;
        }
    
        public class SecretIngredient : DrinkDecorator
        {
            public SecretIngredient(Drink drink) : base(drink) { }
            public override string Description => $"{drink.Description} with {nameof(SecretIngredient)} ";
        }
    
        public class Ice : DrinkDecorator
        {
            public Ice(Drink drink) : base(drink) { }
            public override string Description => $"{drink.Description} with {nameof(Ice)} ";
        }
    }
