    public class CubeBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        //Detect current clicks on the GameObject (the one with the script attached)
        public void OnPointerDown(PointerEventData pointerEventData)
        {
            //Output the name of the GameObject that is being clicked
            Debug.Log(name + " click down at position " + transform.position);
        }
        //Detect if clicks are no longer registering
        public void OnPointerUp(PointerEventData pointerEventData)
        {
            Debug.Log(name + "No longer being clicked");
        }
    }
