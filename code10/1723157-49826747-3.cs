    public class FirstContainer : IBaseContainer
    {
        public void Add<T>(T param) where T : ICanBeHeldInFirstContainer 
        {
            // Do Something
        }
    }
