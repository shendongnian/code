    public abstract class Animal<TFood> : IAnimal where TFood : Food
    {
        public void Feed(TFood food)
        {
            // we either need to check for null here
        }
        public void Feed(Food food)
        {
            // or we need to check food is TFood here
            Feed(food as TFood);
        }
    }
