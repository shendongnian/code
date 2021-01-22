    struct Person {
        public string name; // mutable
        public Point position = new Point(0, 0); // mutable
        public Person(string name, Point position) { ... }
    }
    
    Person eric = new Person("Eric Lippert", new Point(4, 2));
