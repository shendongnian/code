    public class B : ScriptableObject
    {
        // You don't need [SerializeField] since public properties
        // are serialized anyway
        public A a;
        // Internal for removing listeners later
        private A lastA;
        private void OnValidate()
        {
            Debug.Log("reference a changed");
            // Unregister listeners for old reference
            if(lastA)
            {
                lastA.onChanged -= OnAChanged;
                lastA.onReset -= OnAReset;
                lastA.onDestroyed -= OnADestroyed;
            }
            // Register listeners for new reference
            // Note that it is allways possible to remove listeners first
            // even if they are not there yet
            // that makes sure you listen only once
            if(a)
            {
                a.onChanged -= OnAChanged;
                a.onReset -= OnAReset;
                a.onDestroyed -= OnADestroyed;
                a.onChanged += OnAChanged;
                a.onReset += OnAReset;
                a.onDestroyed += OnADestroyed;
            }
            lastA = a;
        }
        // Make allways sure you also remove all listeners on destroy to not get Null reference exceptions
        // Note that it is allways possible to remove listeners even if they are not there yet
        private void OnDestroy()
        {
            if(!a) return;
            a.onChanged -= OnAChanged;
            a.onReset -= OnAReset;
            a.onDestroyed -= OnADestroyed;
        }
        private void OnAChanged()
        {
            Debug.Log("A was changed");
        }
        private void OnAReset()
        {
            Debug.Log("A was reset");
        }
        private void OnADestroyed()
        {
            Debug.Log("a was destroyed");
        }
    }
       
    }
