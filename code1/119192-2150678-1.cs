    /// <summary>
    /// This structure controls blending by specifying the blending functions for source and destination bitmaps. 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct BlendFunction
    {
    	/// <summary>
    	/// Specifies the source blend operation. Currently, the only source and destination blend operation that has been defined is AC_SRC_OVER. For details, see the following Remarks section.
    	/// </summary>
    	public byte BlendOp;
    
    	/// <summary>
    	/// Must be zero.
    	/// </summary>
    	public byte BlendFlags;
    
    	/// <summary>
    	/// Specifies an alpha transparency value to be used on the entire source bitmap. The SourceConstantAlpha value is combined with any per-pixel alpha values in the source bitmap. If you set SourceConstantAlpha to 0, it is assumed that your image is transparent. When you only want to use per-pixel alpha values, set the SourceConstantAlpha value to 255 (opaque) .
    	/// </summary>
    	public byte SourceConstantAlpha;
    
    	/// <summary>
    	/// This member controls the way the source and destination bitmaps are interpreted. The following table shows the value for AlphaFormat. 
    	/// ---
    	/// AC_SRC_ALPHA   This flag is set when the bitmap has an Alpha channel (that is, per-pixel alpha). Because this API uses premultiplied alpha, the red, green and blue channel values in the bitmap must be premultiplied with the alpha channel value. For example, if the alpha channel value is x, the red, green and blue channels must be multiplied by x and divided by 0xff before the call. 
    	/// </summary>
    	public byte AlphaFormat;
    
    	/// <summary>
    	/// 	Initializes a new instance of the <see cref="BlendFunction"/> structure.
    	/// </summary>
    	/// <param name="alphaConst">Specifies an alpha transparency value to be used on the entire source bitmap.
    	/// </param>
    	/// <param name="alphaFormat">Alpha flag
    	/// </param>
    	public BlendFunction(byte alphaConst, byte alphaFormat)
    	{
    		this.BlendOp = 0;
    		this.BlendFlags = 0;
    		this.SourceConstantAlpha = alphaConst;
    		this.AlphaFormat = alphaFormat;
    	}
    }
