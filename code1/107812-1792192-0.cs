        public interface IAnimal { }
        public class Orangutan : IAnimal { }
        public void ValidateUsing<T>(Action<T> action) where T : IAnimal
        {
            Orangutan orangutan = new Orangutan();
            action((T)(orangutan as IAnimal));  // needs to be cast as IAnimal
            //This doesn't work either:
            IAnimal animal = new Orangutan();
            action((T)animal);  // needs to be cast as T
        }
