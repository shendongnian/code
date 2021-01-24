    using UnityEngine;
    
    public class PathCreator : MonoBehaviour
    {
    
      public Path path;
    
      public Path CreatePath()
      {
        return path = new Path(transform.position);
      }
    
      void Reset()
      {
        CreatePath();
      }
    }
