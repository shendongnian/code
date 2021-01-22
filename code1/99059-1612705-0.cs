    if (!atom.IsStatic)
    {
        if (atom.Position.X - atom.Radius < _min.X && atom.Velocity.X < 0)
        {
            atom.ReverseVelocityDirection(true, false);
        }
        if (atom.Position.X + atom.Radius > _max.X && atom.Velocity.X > 0)
        {
            atom.ReverseVelocityDirection(true, false);
        }
        if (atom.Position.Y - atom.Radius < _min.Y && atom.Velocity.Y < 0)
        {
            atom.ReverseVelocityDirection(false, true);
        }
        if (atom.Position.Y + atom.Radius > _max.Y && atom.Velocity.Y > 0)
        {
            atom.ReverseVelocityDirection(false, true);
        }
    }
