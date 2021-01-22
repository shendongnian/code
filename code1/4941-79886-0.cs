        private delegate void SpacialItemVisitor(ISpacialItem item);
        protected override void Update(GameTime gameTime)
        {
            m_quadTree.Visit(ref explosionCircle, ApplyExplosionEffects);
        }
        private void ApplyExplosionEffects(ISpacialItem item)
        {
        }
