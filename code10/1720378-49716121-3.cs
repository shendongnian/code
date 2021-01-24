    public class GameObjectAutoAdd : MonoBehaviour
    {
        void Awake()
        {
            //Add this GameObject to List when it is created
            GameObjectManager.instance.allObjects.Add(gameObject);
        }
    
        void OnDestroy()
        {
            //Remove this GameObject from the List when it is about to be destroyed
            GameObjectManager.instance.allObjects.Remove(gameObject);
        }
    }
