    public class Example : MonoBehaviour, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            Debug.Log("Currently hovering " + name, this);
        }
    }
