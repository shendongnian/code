        class Window : Control, ISquareControl
        {
            private SquareControl square;
            
            public void SquareOperation()
            {
                square.SquareOperation();
            }
        }
        
        class SquareControl : Control, ISquareControl
        {
            public void SquareOperation()
            {
                // ...
            }
        }
