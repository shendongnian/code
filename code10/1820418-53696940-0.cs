            foreach (Entity entity in EntityPool) // Loop through all entities
            {
                Dictionary<Type, IComponent> components = entity.Components;
                if (components.TryGetValue(typeof(Position), out IComponent positionComponent))
                {
                    Position position = (Position)positionComponent;
                    if (components.TryGetValue(typeof(MovementSpeed), out IComponent movementSpeedComponent))
                    {
                        MovementSpeed speed = (MovementSpeed)movementSpeedComponent;
                        // TEST: move (1 * movementspeed) units
                        position.X += speed.Value;
                        position.Y += speed.Value;
                    }
                }
            }
    
