    public class A : ScriptableObject
    {
        // You don't need [SerializeField] if the property is public
        public string team;
        public event Action onChanged;
        public event Action onReset;
        public event Action onDestroyed;
        private void OnValidate()
        {
            Debug.Log($"My team name has been changed to {team}.");
            if(onChanged == null) return;
            onChanged.Invoke();
        }
        // This is called on reset
        // But if you override this you have to set
        // The default values yourself!
        private void Reset()
        {
            team = "";
            
            if (onReset == null) return;
            onReset.Invoke();
        }
        // Called when object is destroyed
        private void OnDestroyed()
        {
            if(onDestroyed == null) return;
            onDestroyed.Invoke();
        }
    }
