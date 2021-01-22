    public class MD2_Header {
      public int FourCC { get; set; }
      public int Version { get; set; };
      public int TextureWidth { get; set; };
      public int TextureHeight { get; set; };
      public int FrameSizeInBytes { get; set; };
      public int NbrTextures { get; set; };
      public int NbrVertices { get; set; };
      public int NbrTextureCoords { get; set; };
      public int NbrTriangles { get; set; };
      public int NbrOpenGLCmds { get; set; };
      public int NbrFrames { get; set; };
      public int TextureOffset { get; set; };
      public int TexCoordOffset { get; set; };
      public int TriangleOffset { get; set; };
      public int FrameOffset { get; set; };
      public int OpenGLCmdOffset { get; set; };
      public int EndOffset { get; set; };
      public MD2_Header(byte[] values) {
        FourCC = BitConverter.ToInt32(values, 0);
        Version = BitConverter.ToInt32(values, 4);
        TextureWidth = BitConverter.ToInt32(values, 8);
        TextureHeight = BitConverter.ToInt32(values, 12);
        FrameSizeInBytes = BitConverter.ToInt32(values, 16);
        NbrTextures = BitConverter.ToInt32(values, 20);
        NbrVertices = BitConverter.ToInt32(values, 24);
        NbrTextureCoords = BitConverter.ToInt32(values, 28);
        NbrTriangels = BitConverter.ToInt32(values, 32);
        NbrOpenGLCmds = BitConverter.ToInt32(values, 36);
        NbrFrames = BitConverter.ToInt32(values, 40);
        TextureOffset = BitConverter.ToInt32(values, 44);
        TexCoordOffset = BitConverter.ToInt32(values, 48);
        TriangleOffset = BitConverter.ToInt32(values, 52);
        FrameOffset = BitConverter.ToInt32(values, 56);
        OpenGLCmdOffset = BitConverter.ToInt32(values, 60);
        EndOffset = BitConverter.ToInt32(values, 64);
      }
    }
