    using UnityEngine;
    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    [ExecuteInEditMode]
    public class PrintAwake : MonoBehaviour
    {
        #if UNITY_EDITOR
        void Awake()
        {
            if(!EditorApplication.isPlaying)
                Debug.Log("Editor causes this Awake");
        }
        #endif
    }
