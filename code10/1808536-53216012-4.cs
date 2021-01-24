      public class DogCollection<T> : ObservableCollection<T>
      {
        public new void Add(T animal)
        {
          if (animal is Dog)
            base.Add(animal);
          throw new InvalidCastException("Animal is not a Dog");
        }
      }
