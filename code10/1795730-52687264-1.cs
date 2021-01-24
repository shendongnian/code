    [DllImport("test22")]
    private static extern float ProcessImage(IntPtr texData, int width, int height);
    
    unsafe void ProcessImage(Texture2D texData)
    {
        Color32[] texDataColor = texData.GetPixels32();
        System.Array.Reverse(texDataColor);
        //Pin Memory
        fixed (Color32* p = texDataColor)
        {
            ProcessImage((IntPtr)p, texData.width, texData.height);
        }
        //Update the Texture2D with array updated in C++
        texData.SetPixels32(texDataColor);
        texData.Apply();
    }
