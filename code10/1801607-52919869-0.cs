    class Destroyable : MonoBehaviour, IPointerClickHandler {
        public void OnPointerClick(PointerEventData eventData)
        {
            Destroy(gameObject);
        }
    }
