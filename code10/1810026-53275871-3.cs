    class MyObj 
    { 
        public void SetEquals(MyObj other)
        {
            if (object.ReferenceEquals(this, other)) return; // We are equal by reference, so do nothing.
            this.Property1 = other.Property1;
            this.Property2 = other.Property2;
            this.Property3 = other.Property3;
            // ...
        }
    }
