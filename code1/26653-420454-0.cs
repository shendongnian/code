        struct MyStruct {
            public MyStruct(int size)
                : this() {
                this.Size = size; // <-- Compile-Time Error!
            }
            public int Size { get; set; }
        }
