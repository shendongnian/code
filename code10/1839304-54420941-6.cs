    public interface BaseClassVisitor {
        void Visit(IntChild intChild);
        void Visit(...); // all the other possible types
        ...
    }
