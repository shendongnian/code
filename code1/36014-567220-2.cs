            using(MyOwnObjectThatImplementsIDisposable MyObject = new MyOwnObjectThatImplementsIDisposable)
            {
                // When the statement finishes, it calls the 
                // code you´ve writed in Dispose method
                // of MyOwnObjectThatImplementsIDisposable class
            }
