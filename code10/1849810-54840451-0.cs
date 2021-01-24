    public class InventoryUIDetails : MonoBehaviour {
    
        void Start() {
            ...
            itemInteractButton.onClick.AddListener (OnItemInteract);
        }
        void OnDestroy() {
            itemInteractButton.onClick.RemoveListener (OnItemInteract);
        }
    
        public void OnItemInteract() {
            if (item == null)
                return;
            ...
        }
    }
