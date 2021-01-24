    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class ShrinkWrapSphere : MonoBehaviour {
    
    	void Start() {
            Debug.Log("Starting...");
    
            MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
            Mesh mesh = meshFilter.mesh;
            
            Vector3[] vertices = new Vector3[mesh.vertices.Length];
            System.Array.Copy(mesh.vertices, vertices, vertices.Length);
            
            for (int i = 0; i < vertices.Length; i++) {
                Vector3 rayDirection = -mesh.normals[i];
    
                RaycastHit hit;
                if ( Physics.Raycast( vertices[i], rayDirection, out hit, 100f ) ) {
                    vertices[i] = hit.point * 2f;
                }
                else {
                    vertices[i] = Vector3.zero;
                }
            }
            
            mesh.vertices = vertices;
    
            Debug.Log("Done. Vertices count " + vertices.Length);
    		
    		// mesh.RecalculateBounds();
            // mesh.RecalculateNormals();
            // mesh.RecalculateTangents();
    	}
    	
    }
