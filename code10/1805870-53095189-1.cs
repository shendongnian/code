    public class RoamingSibling : MonoBehaviour {
         
         private Transform _parent;
         private int _siblingIndex;
         public void Awake () {
              _parent = transform.parent;
              _siblingIndex = transform.GetSiblingIndex();
         }
         
         //Leave the parent and go off on its own!
         public void Leave () { 
              transform.SetParent(null);
         }
        
         //Come back to the parent!
         public void Rejoin () {
              transform.SetParent(_parent);
              transform.SetSiblingIndex(_siblingIndex);
         }
    }
