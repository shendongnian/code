    public abstract class Animal<TFood> : IAnimal where TFood : Food
    {
        public void Feed(TFood food)
        {
        }
        public void Feed(Food food)
        {
            Feed(food as TFood);
        }
    }
