    using UnityEngine;
    
    namespace Assets
    {
        public class Test : MonoBehaviour
        {
            public Texture2D Texture2D;
    
            private void OnEnable()
            {
                var terrain = GetComponent<Terrain>();
                var data = terrain.terrainData;
                var hw = data.heightmapWidth;
                var hh = data.heightmapHeight;
                var heights = data.GetHeights(0, 0, hw, hh);
    
                for (var y = 0; y < hh; y++)
                {
                    for (var x = 0; x < hw; x++)
                    {
                        // normalize coordinates
                        var x1 = 1.0f / hw * x * Texture2D.width;
                        var y1 = 1.0f / hh * y * Texture2D.height;
    
                        // get color height
                        var pixel = Texture2D.GetPixel((int) x1, (int) y1);
                        var f = pixel.grayscale; // defines height
                        var g = f * f * f; // some smoothing
                        var s = 0.025f; // some scaling
    
                        heights[x, y] = g * s;
                    }
                }
    
                data.SetHeights(0, 0, heights);
            }
        }
    }
