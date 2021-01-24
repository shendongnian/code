    public class GameObjectSpawner : MonoBehaviour 
    {
        public GameObject GameObjectPrefab;
        public GameObjectEvent OnCreateObject;
        private void Update() 
        {
            // Everytime you click your left mouse button
            // Only runs once per mouse click
            if (Input.GetMouseButtonDown(0)) 
            {
                // Instantiate the gameobject...
                GameObject go = Instantiate(GameObjectPrefab);
                // Then immediately Invoke our event to run all the listeners
                // and passing our gameobject to them.
                OnCreateObject.Invoke(go);
            }
        }
    }
    
    // This is just so the code that 'listens' to the event can get access to the 
    // gameobject that just got instantiated.
    public class GameObjectEvent : UnityEvent<GameObject> { }
