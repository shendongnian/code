        public void Update2()
        {
            List<IComponent> list = new List<IComponent>();
            list.OfType<Position>().ToList().ForEach(p =>
            {
                var speed = list.OfType<MovementSpeed?>().FirstOrDefault();
                if (speed.HasValue)
                {
                    p.X = speed.Value.Value;
                    p.Y = speed.Value.Value;
                }
            });
        }
