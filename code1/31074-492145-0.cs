            public void Foo(Enum e)
            {
                var names = Enum.GetNames(e.GetType());
                foreach (var name in names)
                {
                    // do something!
                }
            }   
