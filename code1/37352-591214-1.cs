    class Car : GameComponent
    {
        public override void Update(GameTime time)
        {
             velocity += acceleration * time.ElapsedGameTime.TotalSeconds;
             position += velocity * time.ElapsedGameTime.TotalSeconds;
        }
        Vector3 position;
        Vector3 velocity;
        Vector3 acceleration;
    }
