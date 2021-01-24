    using UnityEngine;
    using System.Collections;
    public class createMesh : MonoBehaviour {
        public float width = 5f;
        public float height = 5f;
        public PolygonCollider2D polyCollider;
        void Start()
        {
            polyCollider = GetComponent<PolygonCollider2D>();
        }
	
	    // Update is called once per frame
	    void Update () {
            TriangleMesh(width, height);
        }
        void TriangleMesh(float width, float height)
        {
            MeshFilter mf = GetComponent<MeshFilter>();
            Mesh mesh = new Mesh();
            mf.mesh = mesh;
            //Verticies
            Vector3[] verticies = new Vector3[3]
            {
                new Vector3(0,0,0), new Vector3(width, 0, 0), new Vector3(0, 
    height, 0)
            };
            //Triangles
            int[] tri = new int[3];
            tri[0] = 0;
            tri[1] = 2;
            tri[2] = 1;
            //normals
            Vector3[] normals = new Vector3[3];
            normals[0] = -Vector3.forward;
            normals[1] = -Vector3.forward;
            normals[2] = -Vector3.forward;
            //UVs
            Vector2[] uv = new Vector2[3];
            uv[0] = new Vector2(0, 0);
            uv[0] = new Vector2(1, 0);
            uv[0] = new Vector2(0, 1);
            //initialise
            mesh.vertices = verticies;
            mesh.triangles = tri;
            mesh.normals = normals;
            mesh.uv = uv;
            //setting up collider
            polyCollider.pathCount = 1;
            Vector2[] path = new Vector2[3]
            {
                new Vector2(0,0), new Vector2(0, height), new Vector2(width, 0)
            };
            polyCollider.SetPath(0, path);
        }
    }
