    public class Car {
        public enum Make {
            Chevy,
            Ford
        };
        // No good, need to pull Make out of the class or create
        // a name that isn't exactly what you want
        public Make Make {
            get; set;
        }
    }
