    using UnityEngine;
    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    
    [ExecuteInEditMode]
    public class PrintAwake : MonoBehaviour
    {
        #if UNITY_EDITOR
        void Start() {
            if(!EditorApplication.isPlaying) {
                Debug.Log("Editor causes this START!!");
            	RandomSpinSetup();
            	}
        }
        #endif
        private void RandomSpinSetup() {
        	float r = Random.Range(3,8) * 10f;
        	transform.eulerAngles = new Vector3(0f, r, 0f);
        	name = "Cube: " + r + "°";
        }
    }
