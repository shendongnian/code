    public interface ISorter {
       // Prototype for your sort function goes here
    }
    public class QuickSorter implements ISorter {}
    
    public class SorterFactory {
       public ISorter getSorter( string sortType ) {
          // Return the correct type of sorting algorithm
          if ( sortType.equals( "QuickSort" ) ) {
             return new QuickSorter();
          }
       }
    }
    Then you just lookup what the user selected in the database and pass that in as the parameter to the factory.
