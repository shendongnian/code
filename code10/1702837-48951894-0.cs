    public class Hook : MonoBehaviour {
    
        // Stores a Cord and its "other" Hook
        Dictionary<Hook, Cord> attached = new Dictionary<Hook, Cord>();
    
        // Add a Cord by retrieving its "other" Hook and using it as a key
        public void Attach(Cord c) {
            if (!ConflictTest(c)){
                attached.Add(GetOtherHook(c), c);
            }
        }
    
        // Remove a cord based on its "other" Hook
        public void Detach(Cord c) {
            attached.Remove(GetOtherHook(c));
        }
    
        // Determine whether current connections contain this Cord's "other" Hook
        bool ConflictTest(Cord toAttach) {
            return attached.ContainsKey(GetOtherHook(toAttach));
        }
    
        // Retrieves the "other" (non-current Hook) a cord is attached to
        private Hook GetOtherHook(Cord c) {
            return c.end != this ? c.end : c.start;
        }
    }
