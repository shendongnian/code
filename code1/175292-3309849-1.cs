    private void PostSolve(ContactConstraint contactConstraint)
    {
        if (!Broken)
        {
            float maxImpulse = 0.0f;
            for (int i = 0; i < contactConstraint.manifold.PointCount; ++i)
            {
                maxImpulse = Math.Max(maxImpulse,
                             contactConstraint.manifold.Points[0].NormalImpulse);
                maxImpulse = Math.Max(maxImpulse,
                             contactConstraint.manifold.Points[1].NormalImpulse);
            }
            if (maxImpulse > Strength)
            {
                // Flag the body for breaking.
                _break = true;
            }
        }
    }
