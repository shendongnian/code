    public class VegetableManager {
      private static Collection<Vegetable> _veggies;
      private static object _veggieLock;
    
      static VegetableManager() {
        // logic to load veggies from file
      }
      public ReadOnlyCollection<Vegetable> GetAll() {
        return new ReadOnlyCollection(_veggies);
      }
    
      public void Add(Vegetable veggie) {
        lock(_veggieLock) { //synchronize access to shared data
          _veggies.Add(veggie);
          // logic to write out the updated list of _veggies to the file
        }
      }
    }
