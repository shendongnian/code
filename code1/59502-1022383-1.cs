    public static void DrawBlendImage(Graphics canvas, Image source, Color blendColor, float blendLevel, int x, int y)
    {
      Rectangle SourceBounds = new Rectangle(x, y, source.Width, source.Height);
      ColorMatrix MaskMatrix = new ColorMatrix();
      MaskMatrix.Matrix00 = 0f;
      MaskMatrix.Matrix11 = 0f;
      MaskMatrix.Matrix22 = 0f;
      MaskMatrix.Matrix40 = (float)blendColor.R / byte.MaxValue;
      MaskMatrix.Matrix41 = (float)blendColor.G / byte.MaxValue;
      MaskMatrix.Matrix42 = (float)blendColor.B / byte.MaxValue;
      ImageAttributes MaskAttributes = new ImageAttributes();
      MaskAttributes.SetColorMatrix(MaskMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
      ColorMatrix TransparentMatrix = new ColorMatrix();
      TransparentMatrix.Matrix33 = blendLevel;
      ImageAttributes TransparentAttributes = new ImageAttributes();
      TransparentAttributes.SetColorMatrix(TransparentMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
      canvas.DrawImage(source, SourceBounds, 0, 0, source.Width, source.Height, GraphicsUnit.Pixel, MaskAttributes);
      canvas.DrawImage(source, SourceBounds, 0, 0, source.Width, source.Height, GraphicsUnit.Pixel, TransparentAttributes);
    }
