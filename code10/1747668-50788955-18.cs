    using UnityEngine;
    
    public class PathCreator : MonoBehaviour
    {
    
      public Path path;
    
      public Path CreatePath()
      {
        return path = new Path(Vector2.zero);
      }
    
      void Reset()
      {
        CreatePath();
      }
    }
