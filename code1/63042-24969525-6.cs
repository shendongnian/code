    public static class Animal
    {
        public static readonly ID dog = 1;
        public static class dogs
        {
            public static readonly ID bulldog = dog[0];
            public static readonly ID greyhound = dog[1];
            public static readonly ID husky = dog[3];
        }
    
        public static readonly ID cat = 2;
        public static class cats
        {
            public static readonly ID persian = cat[0];
            public static readonly ID siamese = cat[1];
            public static readonly ID burmese = cat[2];
        }
    
        public static readonly ID reptile = 3;
        public static class reptiles
        {
            public static readonly ID snake = reptile[0];
            public static class snakes
            {
                public static readonly ID adder = snake[0];
                public static readonly ID boa = snake[1];
                public static readonly ID cobra = snake[2];
            }
    
            public static readonly ID lizard = reptile[1];
            public static class lizards
            {
                public static readonly ID gecko = lizard[0];
                public static readonly ID komodo = lizard[1];
                public static readonly ID iguana = lizard[2];
                public static readonly ID chameleon = lizard[3];
            }
        }
    }
