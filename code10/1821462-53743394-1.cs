     class Apple
        {
            private static Random rng = new Random();
            public int weight;
            public Apple()
            {
                weight = rng.Next(80, 121);
            }
        }
