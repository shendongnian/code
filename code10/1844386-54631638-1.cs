    public class Example : MonoBehaviour, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            // passing in "this" as context additionally allows to 
            // click on the log to highlight the object where it came from
            Debug.Log("Currently hovering " + name, this);
        }
    }
