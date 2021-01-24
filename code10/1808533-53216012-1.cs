    public class BuildZoo
    {
      private ObservableCollection<Animal> cats = new ObservableCollection<Animal>();
      private ObservableCollection<Animal> dogs = new ObservableCollection<Animal>();
      private ObservableCollection<Animal> birds = new ObservableCollection<Animal>();
    
      private ObservableCollection<ObservableCollection<Animal>> zoo =
      new ObservableCollection<ObservableCollection<Animal>>();
      public void construct ()
      { zoo. Add(cats);
        zoo.Add(dogs);
        zoo.Add(birds);
        cats.Add(new Cat());
        dogs.Add(new Dog());
        birds.Add(new Bird());
      }
    }
