    // By making a class abstract it can not be instanced itself but only be implemented by subclasses
    public abstract class BaseMovement : MonoBehaviour
    {
        // fields that will be inherited by subclasses
        public int currentWaypointIndex;
        public int nextWaypointIndex;
        //...
        // You could also have some generic methods that are implemented
        // only in the subclasses like e.g. Getters for the values
        // you want to access
        public abstract string SaySomething();
    }
