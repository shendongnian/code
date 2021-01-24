    using System.Linq;
    ...
    List<GameObject> myList = new List<GameObject>();
    public GameObject GetGameObjectWithCameraComponent() {
        return myList.FirstOrDefault(item => item.GetComponent<Camera>() != null);
    }
    
    public IEnumerable<GameObject> GetAllGameObjectsWithCameraComponent() {
        return myList.Where(item => item.GetComponent<Camera>() != null);
    }
