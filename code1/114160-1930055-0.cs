    public class Spring : IForce
    {
        private Particle ThisParticle;
        private Particle ThatParticle;
        private float K;
        public Spring(Particle thisParticle, Particle thatParticle, float k)
        {
            ThisParticle = thisParticle;
            ThatParticle = thatParticle;
        }
        public void Update(Particle particle, GameTime gameTime)
        {            
            float X = Vector3.Length(ThisParticle - ThatParticle);
            
            ThisParticle.Forces.Add(K * X);
        }
    }
