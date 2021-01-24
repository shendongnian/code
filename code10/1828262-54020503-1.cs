    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    using UnityEngine;
    
    public class ChessFieldDebug : MonoBehaviour
    {
        #if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            // ...
        }
        #endif
    }
