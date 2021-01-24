    public class SetValueVisitor : BaseClassVisitor {
        void Visit(IntChild intChild) { intChild.Value = 1; }
        void Visit(BoolChild boolChild) { boolChild.Value = false; }
        ...
    }
