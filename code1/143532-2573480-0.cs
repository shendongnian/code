    public class DrinkModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDrinkable>()
                .To<Coke>()
                .Only(When.ContextVariable("Name").EqualTo("Coke"));
            Bind<IDrinkable>()
                .To<Pepsi>()
                .Only(When.ContextVariable("Name").EqualTo("Pepsi"));
            // And so on
        }
    }
