    public class Test : MonoBehaviour, IPointerClickHandler
    {
        public static List<GameObject> Objects = new List<GameObject>();
    
        public void OnPointerClick(PointerEventData eventData)
        {
            GameObject clickedObj = eventData.pointerCurrentRaycast.gameObject;
    
            int index = GameObjectToIndex(clickedObj);
            Debug.Log(index);
        }
    
        int GameObjectToIndex(GameObject targetObj)
        {
            //Loop through GameObjects
            for (int i = 0; i < Objects.Count; i++)
            {
                //Check if GameObject is in the List
                if (Objects[i] == targetObj)
                {
                    //It is. Return the current index
                    return i;
                }
            }
            //It is not in the List. Return -1
            return -1;
        }
    }
