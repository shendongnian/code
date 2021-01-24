    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    [ExecuteInEditMode]
    public class Box: MonoBehaviour
    {
        public Vector3 dimensions;   
    
        private void Start()
        {
            
            this.GetComponent<MeshFilter>().sharedMesh.recalculateMeshByBounds(dimensions);
        }
    
        private void Update()
        {
            
        }
    }
