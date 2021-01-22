    abstract class BaseListTest {
      abstract public List newListInstance();
      public void testAddToList() {
        // do some adding tests
      }
      public void testRemoveFromList() {
        // do some removing tests
      }
    }
    class ArrayListTest < BaseListTest {
      List newListInstance() { new ArrayList(); }
      public void arrayListSpecificTest1() {
        // test something about ArrayLists beyond the List requirements
      }
    }
