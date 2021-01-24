    public class EffectManager
    {
        Dictionary<Type, ActiveEffect> _activeEffects = new Dictionary<Type, ActiveEffect>();
        public void AddEffect(IEffect effect)
        {
            var type = effect.GetType();
            if (_activeEffects.ContainsKey(type))
            {
                //reseting effect duration to max
                _activeEffects[type].LeftTime = effect.Duration;
            }
            else
            {
                var activeEffect = new ActiveEffect(effect);
                _activeEffects.Add(type, activeEffect);
                StartCoroutine(activeEffect);
            }
        }
        private IEnumerator Apply(ActiveEffect effect)
        {
            effect.Effect.Do(player);
            while (effect.LeftTime > 0)
            {
                yield return new WaitForEndOfFrame();
                effect.LeftTime -= Time.deltaTime;
            }
            effect.Effect.Undo(player);
            _activeEffects.Remove(effect.Effect.GetType());
        }
    }
