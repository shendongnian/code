    class Factory {
        public MyClass createDefault() {
            return new MyClass(new ConcreteDependency());
        }
    }
