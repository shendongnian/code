    public class VegetableManager {
      private static Collection<VegetableManager> _veggies;
      private static object _veggieLock;
    
      public ReadOnlyCollection<VegetableManager> GetAll() {
        if (_veggies == null) {
          lock(_veggieLock) { //synchronize access to shared data
            if (_veggies == null) { // double-checked lock
              // logic to load the data into _veggies
            }
          }
        }
    
        return new ReadOnlyCollection(_veggies);
      }
    
      public void Add(Vegetable veggie) {
        GetAll(); // call this to ensure that the data is loaded into _veggies
        lock(_veggieLock) { //synchronize access to shared data
          _veggies.Add(veggie);
          // logic to write out the updated list of _veggies to the file
        }
      }
    }
