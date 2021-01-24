            var movement = new Movement();
            var builder = new ContainerBuilder();
            builder.RegisterType<Body>().As<IBody>();
            builder.RegisterType<Display>().As<IDisplay>();
            builder.RegisterType<Draw>().As<IDraw>();
            builder.RegisterType<Food>().As<IFood>();
            **builder.RegisterInstance<IMovement>(movement);**
            builder.RegisterType<SnakeGame>().As<ISnakeGame>();
            builder.RegisterType<ISenseHat>().As<ISenseHat>();
            var container = builder.Build();
