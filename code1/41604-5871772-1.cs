        public static void PushPlanets(Planet[] planets)
        {
            // Position Push at iteration N + 0:
            foreach(var p in planets)
                p.Position += Gravity.dT * p.Velocity; // Velocity from N - 1/2
            // Velocity Push at iteration N + 1/2:
            foreach (var p in planets)
            {
                Vector TotalGravity = new Vector(0,0);
                foreach (var pN in planets)
                {
                    if (pN == p) continue;
                    TotalGravity += pN.Mass * p.Mass * GravityAccelerationVector(p.Position - pN.Position);
                }
                TotalGravity += Sun.Mass * p.Mass * GravityAccelerationVector(p.Position); // Solar acceleration
                p.Velocity += Gravity.dT * TotalGravity;
            }
