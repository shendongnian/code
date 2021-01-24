    public Room : MonoBehaviour
    {
       UnityEvent OnRoomEnter;
    
       public void OnEnable() // Or whatever function you call when instantiating a room
       {
          OnRoomEnter();
       }
       
    }
