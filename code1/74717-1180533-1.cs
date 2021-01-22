    public interface ISorter {
       // Prototype for your sort function goes here
    }
    public class QuickSorter : ISorter {}
    
    public class SorterFactory {
       public ISorter getSorter( string sortType ) {
          // Return the correct type of sorting algorithm
          if ( sortType.equals( "QuickSort" ) ) {
             return new QuickSorter();
          }
       }
    }
