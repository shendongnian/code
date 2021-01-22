    abstract class MyBase {
        protected MyBase() {
            if (GetType().GetConstructor(Type.EmptyTypes) == null)
                throw new InvalidProgramException();
        }
    }
