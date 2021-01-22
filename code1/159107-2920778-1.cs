    class Rectangle {
        static Rectangle Create() {
            return new Rectangle();
        }
    }
    
    class Square : Rectangle { }
    
    // code elsewhere
    var shape = Square.Create(); // you might want this to return a square,
                                 // but it's just going to return a rectangle
