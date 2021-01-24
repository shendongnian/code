    public class Character
    {
        private IList<ITemporaryEffect> temporaryEffect;         
        public void UpdateEffects(long currentFrame)
        {
            var outdatedTempEffects = temporaryEffect.Where(p => !p.IsActive(currentFrame));
            temporaryEffects.RemoveRange(outdatedTempEffects);
        }
    }
