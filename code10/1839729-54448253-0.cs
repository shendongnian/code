    public class Resize : MonoBehaviour {
    
        [SerializeField]
        Sprite m_InSprite;
        [SerializeField]
        int width;
        [SerializeField]
        int height;
    
        [ContextMenu("RESIZE+++")]
        public void Test()
        {
            Texture2D tex = GetResizeText(m_InSprite.texture);
            File.WriteAllBytes(@"d:\test.png", tex.EncodeToPNG());
        }
        public Texture2D GetResizeText(Texture2D oldTex)
        {
            Func<Texture2D, int, int, Color> convert = delegate (Texture2D tex, int X, int Y)
            {
                float scaleI = tex.width / (float)width;
                float scaleJ = tex.height / (float)height;
                int I = (int)(scaleI * X);
                int J = (int)(scaleJ * Y);
                scaleI = (scaleI < 1) ? 1 : scaleI;
                scaleJ = (scaleJ < 1) ? 1 : scaleJ;
                int lengthI = (int)scaleI + I;
                int lengthJ = (int)scaleJ + J;
                List<Color> colors = new List<Color>();
                for (int i = I; i < lengthI; i++)
                {
                    for (int j = J; j < lengthJ; j++)
                    {
                        colors.Add(tex.GetPixel(i, j));
                    }
                }
                //TO DO
                //here you need to find the median of the List colors, but I was too lazy
                int length = colors.Count;
                int m1 = length / 2;
                return colors[m1];
            };
            Texture2D texResize = new Texture2D(width, height);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color col = convert(oldTex, x, y);
                    texResize.SetPixel(x, y, col);
                }
            }
            return texResize;
        }
    }
