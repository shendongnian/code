             using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    namespace foo {
        public class FurBehavior : MonoBehaviour
        {
            public Material material;
    
    
            public Vector3 pos = new Vector3(0f, 0.98f, -9.54f);
    
    
            //simple camera for use in the game
            private new Camera camera;
            //texture containing fur data
            public Texture2D furTexture;
            //effect for fur shaders
            //Effect furEffect;
            //number of layers of fur
            public int nrOfLayers = 40;
            //total length of the hair
            public float maxHairLength = 2.0f;
            //density of hair
            public float density = 0.2f;
    
            //[Space(20)]
            //public Vector3 dirWorldVal = new Vector3(0, -10, 0);
    
            void Start()
            {
                this.transform.position = new Vector3(0f, 0.98f, -9.54f);
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
                Initialize();
                GenerateGeometry();
            }
    
            public void Update()
            {
                Draw();
               
            }
    
    
            void Initialize()
            {
    
                //Initialize the camera
                camera = Camera.main;
    
                //create the texture
                furTexture = new Texture2D(256, 256, TextureFormat.ARGB32, false);
                furTexture.wrapModeU = TextureWrapMode.Repeat;
                furTexture.wrapModeV = TextureWrapMode.Repeat;
                //furTexture.filterMode = FilterMode.Point;
    
                //fill the texture
                FillFurTexture(furTexture, density);
    
                /*XNA's SurfaceFormat.Color is ARGB.
                //https://gamedev.stackexchange.com/a/6442/98839*/
    
    
                if (material.mainTexture != null)
                {
                    material.mainTexture.wrapModeU = TextureWrapMode.Repeat;
                    material.mainTexture.wrapModeV = TextureWrapMode.Repeat;
                   // material.mainTexture.filterMode = FilterMode.Point;
                }
            }
    
            bool firstDraw = true;
    
            protected void Draw()
            {
                var pos = this.transform.position;
    
                camera.backgroundColor = CornflowerBlue();
    
                Matrix4x4 worldValue = Matrix4x4.Translate(pos);
                Matrix4x4 viewValue = camera.projectionMatrix;
                // viewValue = camera.worldToCameraMatrix;
                Matrix4x4 projectionValue = camera.projectionMatrix;
    
                material.SetMatrix("World", worldValue);
                material.SetMatrix("View", viewValue);
                material.SetMatrix("Projection", projectionValue); //Causes object to disappear
    
                material.SetFloat("MaxHairLength", maxHairLength);
    
                //if (firstDraw)
                    material.SetTexture("_MainTex", furTexture);
    
                //furEffect.Begin();
                for (int i = 0; i < nrOfLayers; i++)
                {
                    var mtl = new Material(material);
    
                    var layer = (float)i / (float)nrOfLayers;
                    mtl.SetFloat("CurrentLayer", layer);
                    mtl.SetFloat("MaxHairLength", maxHairLength);
                    mtl.SetColor("_TintColor", new Color(layer, layer, layer, layer));
                    DrawGeometry(mtl);
                }
    
                if (firstDraw)
                {
                    material.mainTexture.wrapModeU = TextureWrapMode.Repeat;
                    material.mainTexture.wrapModeV = TextureWrapMode.Repeat;
                    material.mainTexture.filterMode = FilterMode.Point;
                }
    
                if (firstDraw)
                    firstDraw = false;
            }
    
            void DrawGeometry(Material mtl)
            {
                var rot = Quaternion.Euler(0, 180, 0);
                Graphics.DrawMesh(verticesMesh, pos, rot, mtl, 0, camera);
            }
    
            private VertexPositionNormalTexture[] verticesPText;
            public Mesh verticesMesh;
    
            private void GenerateGeometry()
            {
                var UnitZ = new Vector3(0, 0, 1);
                var verticesPText = new VertexPositionNormalTexture[6];
                verticesPText[5] = new VertexPositionNormalTexture(new Vector3(-10, 0, 0),
                                                            -UnitZ,
                                                            new Vector2(0, 0));
                verticesPText[4] = new VertexPositionNormalTexture(new Vector3(10, 20, 0),
                                                            -UnitZ,
                                                            new Vector2(1, 1));
                verticesPText[3] = new VertexPositionNormalTexture(new Vector3(-10, 20, 0),
                                                            -UnitZ,
                                                            new Vector2(0, 1));
    
                verticesPText[2] = verticesPText[5];
                verticesPText[1] = new VertexPositionNormalTexture(new Vector3(10, 0, 0),
                                                            -UnitZ,
                                                            new Vector2(1, 0));
                verticesPText[0] = verticesPText[4];
                
            }
    
            Mesh VertexPositionNormalTextureToUnityMesh(VertexPositionNormalTexture[] vpnt)
            {
                Vector3[] vertices = new Vector3[vpnt.Length];
                Vector3[] normals = new Vector3[vpnt.Length];
                Vector2[] uvs = new Vector2[vpnt.Length];
    
                int[] triangles = new int[vpnt.Length];
    
                //Copy variables to create a mesh
                for (int i = 0; i < vpnt.Length; i++)
                {
                    vertices[i] = vpnt[i].Position;
                    normals[i] = vpnt[i].Normal;
                    uvs[i] = vpnt[i].TextureCoordinate;
    
                    triangles[i] = i;
                }
    
                Mesh mesh = new Mesh();
                mesh.vertices = vertices;
                mesh.normals = normals;
                mesh.uv = uvs;
    
                mesh.MarkDynamic();
    
    
                mesh.triangles = triangles;
                            mesh.UploadMeshData(false);
                return mesh;
            }
    
            private void FillFurTexture(Texture2D furTexture, float density)
            {
                //read the width and height of the texture
                int width = furTexture.width;
                int height = furTexture.height;
                int totalPixels = width * height;
    
                //an array to hold our pixels
                Color32[] colors = new Color32[totalPixels];
    
                //random number generator
                System.Random rand = new System.Random();
    
                //initialize all pixels to transparent black
                for (int i = 0; i < totalPixels; i++)
                    colors[i] = TransparentBlack();
    
                //compute the number of opaque pixels = nr of hair strands
                int nrStrands = (int)(density * totalPixels);
    
                //fill texture with opaque pixels
                for (int i = 0; i < nrStrands; i++)
                {
                    int x, y;
                    //random position on the texture
                    x = rand.Next(height);
                    y = rand.Next(width);
                    //put color (which has an alpha value of 255, i.e. opaque)
                   // colors[x * width + y] = new Color32((byte)255, (byte)x, (byte)y, (byte)255);
                   colors[x * width + y] = Gold();
                }
    
                //set the pixels on the texture.
                furTexture.SetPixels32(colors);
                // actually apply all SetPixels, don't recalculate mip levels
                furTexture.Apply();
            }
    
            Color32 TransparentBlack()
            {
                //http://www.monogame.net/documentation/?page=P_Microsoft_Xna_Framework_Color_TransparentBlack
                Color32 color = new Color32(0, 0, 0, 0);
                return color;
            }
    
            Color32 Gold()
            {
                //http://www.monogame.net/documentation/?page=P_Microsoft_Xna_Framework_Color_Gold
                Color32 color = new Color32(255, 215, 0, 255);
                return color;
            }
    
            Color32 CornflowerBlue()
            {
                //http://www.monogame.net/documentation/?page=P_Microsoft_Xna_Framework_Color_CornflowerBlue
                Color32 color = new Color32(100, 149, 237, 255);
                return color;
            }
    
            public static Vector3 UnitZ()
            {
                return new Vector3(0f, 0f, 1f);
            }
        }
    }
