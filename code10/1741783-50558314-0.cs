    interface Visitor {
        void Visit(Target target);
    }
    class Target {
        void Accept(Visitor visitor) {
            visitor.Visit(this); // not just a field but a whole instance
        }
    }
