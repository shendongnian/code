    using System;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    
    /// <summary>
    /// This structure contains parameters related to an image.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct ImageInfo
    {
    	#region Fields
    
    	/// <summary>
    	/// A GUID value that identifies the file format for the native image data. This value is an image format identifier. For more information, see Imaging GUIDs.
    	/// </summary>
    	public Guid RawDataFormat;
    
    	public PixelFormatID PixelFormat;
    
    	public uint Width;
    
    	public uint Height;
    
    	public uint TileWidth;
    
    	public uint TileHeight;
    
    	public double Xdpi;
    
    	public double Ydpi;
    
    	public SinkFlags Flags;
    
    	#endregion
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public struct FILETIME
    {
    	#region Fields
    
    	public int dwLowDateTime;
    
    	public int dwHighDateTime;
    
    	#endregion
    }
    
    [StructLayout(LayoutKind.Sequential)]
    internal struct BitmapData
    {
    	#region Fields
    
    	public int Width;
    
    	public int Height;
    
    	public int Stride;
    
    	public PixelFormatID PixelFormat;
    
    	public IntPtr Scan0;
    
    	public IntPtr Reserved;
    
    	#endregion
    }
    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct STATSTG
    {
    	#region Fields
    
    	[MarshalAs(UnmanagedType.LPWStr)]
    	public string pwcsName;
    
    	public int type;
    
    	public long cbSize;
    
    	public FILETIME mtime;
    
    	public FILETIME ctime;
    
    	public FILETIME atime;
    
    	public int grfMode;
    
    	public int grfLocksSupported;
    
    	public Guid clsid;
    
    	public int grfStateBits;
    
    	public int reserved;
    
    	#endregion
    }
    
    /// <summary>
    /// COM IStream interface
    /// </summary>
    [ComImport]
    [Guid("0000000c-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IStream
    {
    	void Read([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, int cb, IntPtr pcbRead);
    
    	void Write([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, int cb, IntPtr pcbWritten);
    
    	void Seek(long dlibMove, int origin, IntPtr plibNewPosition);
    
    	void SetSize(long libNewSize);
    
    	void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten);
    
    	void Commit(int grfCommitFlags);
    
    	void Revert();
    
    	void LockRegion(long libOffset, long cb, int lockType);
    
    	void UnlockRegion(long libOffset, long cb, int lockType);
    
    	void Stat(out STATSTG pstatstg, int grfStatFlag);
    
    	void Clone(out IStream ppstm);
    }
    
    /// <summary>
    /// Pulled from imaging.h in the Windows Mobile 5.0 Pocket PC SDK
    /// </summary>
    [ComImport]
    [Guid("327ABDAA-072B-11D3-9D7B-0000F81EF32E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    internal interface IBitmapImage
    {
    	uint GetSize(out Size size);
    
    	uint GetPixelFormatID(out PixelFormatID pixelFormat);
    
    	uint LockBits(ref RECT rect, uint flags, PixelFormatID pixelFormat, ref BitmapData lockedBitmapData);
    
    	uint UnlockBits(ref BitmapData lockedBitmapData);
    
    	uint GetPalette(); // This is a place holder
    
    	uint SetPalette(); // This is a place holder
    }
    
    /// <summary>
    /// Pulled from imaging.h in the Windows Mobile 5.0 Pocket PC SDK
    /// </summary>
    [ComImport]
    [Guid("327ABDA7-072B-11D3-9D7B-0000F81EF32E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    internal interface IImagingFactory
    {
    	uint CreateImageFromStream(IStream stream, out IImage image);
    
    	uint CreateImageFromFile(string filename, out IImage image);
    
    	// We need the MarshalAs attribute here to keep COM interop from sending the buffer down as a Safe Array.
    	// uint CreateImageFromBuffer([MarshalAs(UnmanagedType.LPArray)] byte[] buffer, uint size, BufferDisposalFlag disposalFlag, out IImage image);
    	uint CreateImageFromBuffer(IntPtr buffer, uint size, BufferDisposalFlag disposalFlag, out IImage image);
    
    	uint CreateNewBitmap();            // This is a place holder
    
    	uint CreateBitmapFromImage(IImage image, uint width, uint height, PixelFormatID pixelFormat, InterpolationHint hints, out IBitmapImage bitmap);      // This is a place holder
    
    	uint CreateBitmapFromBuffer();     // This is a place holder
    
    	uint CreateImageDecoder();         // This is a place holder
    
    	uint CreateImageEncoderToStream(); // This is a place holder
    
    	uint CreateImageEncoderToFile(ref Guid clsid, string filename, out IImageEncoder encoder);
    
    	uint GetInstalledDecoders([Out] out uint size, [Out] out IntPtr decoders);
    
    	uint GetInstalledEncoders([Out] out uint size, [Out] out IntPtr ecoders);
    
    	uint InstallImageCodec();          // This is a place holder
    
    	uint UninstallImageCodec();        // This is a place holder
    }
    
    /// <summary>
    /// Pulled from imaging.h in the Windows Mobile 5.0 Pocket PC SDK
    /// </summary>
    [ComImport]
    [Guid("327ABDAC-072B-11D3-9D7B-0000F81EF32E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IImageEncoder
    {
    	int InitEncoder(IStream stream);
    
    	int TerminateEncoder();
    
    	int GetEncodeSink();
    
    	int SetFrameDimension(ref Guid dimensionID);
    
    	int GetEncoderParameterListSize(out uint size);
    
    	int GetEncoderParameterList(uint size, out IntPtr @params);
    
    	int SetEncoderParameters(IntPtr param);
    }
    
    /// <summary>
    /// This structure defines the coordinates of the upper-left and lower-right corners of a rectangle. 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct RECT
    {
    	#region Fields
    
    	public int left;
    
    	public int top;
    
    	public int right;
    
    	public int bottom;
    
    	#endregion
    }
    
    // Pulled from imaging.h in the Windows Mobile 5.0 Pocket PC SDK
    internal enum BufferDisposalFlag : int
    {
    	BufferDisposalFlagNone,
    	BufferDisposalFlagGlobalFree,
    	BufferDisposalFlagCoTaskMemFree,
    	BufferDisposalFlagUnmapView
    }
    
    // Pulled from imaging.h in the Windows Mobile 5.0 Pocket PC SDK
    internal enum InterpolationHint : int
    {
    	InterpolationHintDefault,
    	InterpolationHintNearestNeighbor,
    	InterpolationHintBilinear,
    	InterpolationHintAveraging,
    	InterpolationHintBicubic
    }
    
    /// <summary>
    /// These values are flags used to identify the numerical formats of pixels in images.
    /// </summary>
    [Flags]
    public enum PixelFormatID
    {
    	PixelFormatIndexed = 0x00010000,
    
    	PixelFormatGDI = 0x00020000,
    
    	PixelFormatAlpha = 0x00040000,
    
    	PixelFormatPAlpha = 0x00080000,
    
    	PixelFormatExtended = 0x00100000,
    
    	PixelFormatCanonical = 0x00200000,
    
    	PixelFormatUndefined = 0,
    
    	PixelFormat1bppIndexed = (1 | (1 << 8) | PixelFormatIndexed | PixelFormatGDI),
    
    	PixelFormat4bppIndexed = (2 | (4 << 8) | PixelFormatIndexed | PixelFormatGDI),
    
    	PixelFormat16bppGrayScale = (4 | (16 << 8) | PixelFormatExtended),
    
    	PixelFormat8bppIndexed = (3 | (8 << 8) | PixelFormatIndexed | PixelFormatGDI),
    
    	PixelFormat16bppRGB555 = (5 | (16 << 8) | PixelFormatGDI),
    
    	PixelFormat16bppRGB565 = (6 | (16 << 8) | PixelFormatGDI),
    
    	PixelFormat16bppARGB1555 = (7 | (16 << 8) | PixelFormatAlpha | PixelFormatGDI),
    
    	PixelFormat24bppRGB = (8 | (24 << 8) | PixelFormatGDI),
    
    	PixelFormat32bppRGB = (9 | (32 << 8) | PixelFormatGDI),
    
    	PixelFormat32bppARGB = (10 | (32 << 8) | PixelFormatAlpha | PixelFormatGDI | PixelFormatCanonical),
    
    	PixelFormat32bppPARGB = (11 | (32 << 8) | PixelFormatAlpha | PixelFormatPAlpha | PixelFormatGDI),
    
    	PixelFormat48bppRGB = (12 | (48 << 8) | PixelFormatExtended),
    
    	PixelFormat64bppARGB = (13 | (64 << 8) | PixelFormatAlpha | PixelFormatCanonical | PixelFormatExtended),
    
    	PixelFormat64bppPARGB = (14 | (64 << 8) | PixelFormatAlpha | PixelFormatPAlpha | PixelFormatExtended),
    
    	PixelFormatMax = 15
    }
    
    [Flags]
    internal enum SinkFlags : uint
    {
    	// Low-word: shared with ImgFlagx
    	Scalable = 0x0001,
    	HasAlpha = 0x0002,
    	HasTranslucent = 0x0004,
    	PartiallyScalable = 0x0008,
    
    	ColorSpaceRGB = 0x0010,
    	ColorSpaceCMYK = 0x0020,
    	ColorSpaceGRAY = 0x0040,
    	ColorSpaceYCBCR = 0x0080,
    	ColorSpaceYCCK = 0x0100,
    
    	// Low-word: image size info
    	HasRealDPI = 0x1000,
    	HasRealPixelSize = 0x2000,
    
    	// High-word
    	TopDown = 0x00010000,
    	BottomUp = 0x00020000,
    	FullWidth = 0x00040000,
    	Multipass = 0x00080000,
    	Composite = 0x00100000,
    	WantProps = 0x00200000
    }
    
    /// <summary>
    /// Pulled from imaging.h in the Windows Mobile 5.0 Pocket PC SDK
    /// </summary>
    [ComImport]
    [Guid("327ABDA9-072B-11D3-9D7B-0000F81EF32E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true)]
    internal interface IImage
    {
    	uint GetPhysicalDimension(out Size size);
    
    	uint GetImageInfo(ref ImageInfo info);
    
    	uint SetImageFlags(uint flags);
    
    	// "Correct" declaration: uint Draw(IntPtr hdc, ref Rectangle dstRect, ref Rectangle srcRect);
    	uint Draw(IntPtr hdc, ref RECT dstRect, IntPtr srcRect);
    
    	uint PushIntoSink(); // This is a place holder
    
    	uint GetThumbnail(uint thumbWidth, uint thumbHeight, out IImage thumbImage);
    }
    
    /// <summary>
    /// Implmentation for the COM IStream interface
    /// </summary>
    public sealed class StreamOnFile :
    	IStream,
    	IDisposable
    {
    	#region Fields
    
    	private readonly Stream stream;
    	private readonly string fileName;
    
    	#endregion
    
    	#region Constructors
    
    	/// <summary>
    	/// 	Initializes a new instance of the <see cref="StreamOnFile"/> class.
    	/// </summary>
    	/// <param name="fileName">File name to open
    	/// </param>
    	internal StreamOnFile(string fileName)
    	{
    		this.fileName = fileName;
    
    		// prevent another processes/threads (mainly delete from web) from using this file while Imaging API is trying to access it
    		this.stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
    	}
    
    	#endregion
    
    	#region Properties
    
    	/// <summary>
    	/// Gets the file name
    	/// </summary>
    	public string FileName
    	{
    		get
    		{
    			return this.fileName;
    		}
    	}
    
    	#endregion
    
    	#region Methods
    
    	public void Read(byte[] pv, int cb, IntPtr pcbRead)
    	{
    		int val = this.stream.Read(pv, 0, cb);
    		if (pcbRead != IntPtr.Zero)
    		{
    			Marshal.WriteInt32(pcbRead, val);
    		}
    	}
    
    	public void Write(byte[] pv, int cb, IntPtr pcbWritten)
    	{
    		this.stream.Write(pv, 0, cb);
    		if (pcbWritten != IntPtr.Zero)
    		{
    			Marshal.WriteInt32(pcbWritten, cb);
    		}
    	}
    
    	public void Seek(long dlibMove, int origin, IntPtr plibNewPosition)
    	{
    		long val = this.stream.Seek(dlibMove, (SeekOrigin)origin);
    		if (plibNewPosition != IntPtr.Zero)
    		{
    			Marshal.WriteInt64(plibNewPosition, val);
    		}
    	}
    
    	public void SetSize(long libNewSize)
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	public void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	public void Commit(int grfCommitFlags)
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	public void Revert()
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	public void LockRegion(long libOffset, long cb, int lockType)
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	public void UnlockRegion(long libOffset, long cb, int lockType)
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	public void Stat(out STATSTG pstatstg, int grfStatFlag)
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	public void Clone(out IStream ppstm)
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	public void Dispose()
    	{
    		if (this.stream != null)
    		{
    			this.stream.Close();
    		}
    	}
    
    	#endregion
    }
    
    public enum ImageType
    {
    	Undefined,
    	MemoryBMP,
    	BMP,
    	EMF,
    	WMF,
    	JPEG,
    	PNG,
    	GIF,
    	TIFF,
    	EXIF,
    	Icon
    }
    
    public static class BitmapProperties
    {
    	/// <summary>
    	/// Indicates the Microsoft Windowsbitmap (BMP) format.
    	/// </summary>
    	private static readonly Guid ImageFormatBMP = new Guid("B96B3CAB-0728-11D3-9D7B-0000F81EF32E");
    
    	/// <summary>
    	/// Indicates the Enhanced Metafile (EMF) format.
    	/// </summary>
    	private static readonly Guid ImageFormatEMF = new Guid("B96B3CAC-0728-11D3-9D7B-0000F81EF32E");
    
    	/// <summary>
    	/// Indicates the Exif (Exchangeable Image File) format.
    	/// </summary>
    	private static readonly Guid ImageFormatEXIF = new Guid("B96B3CB2-0728-11D3-9D7B-0000F81EF32E");
    
    	/// <summary>
    	/// Indicates the Graphics Interchange Format (GIF) format.
    	/// </summary>
    	private static readonly Guid ImageFormatGIF = new Guid("B96B3CB0-0728-11D3-9D7B-0000F81EF32E");
    
    	/// <summary>
    	/// Indicates the Icon format.
    	/// </summary>
    	private static readonly Guid ImageFormatIcon = new Guid("B96B3CB5-0728-11D3-9D7B-0000F81EF32E");
    
    	/// <summary>
    	/// Indicates the JPEG format.
    	/// </summary>
    	private static readonly Guid ImageFormatJPEG = new Guid("B96B3CAE-0728-11D3-9D7B-0000F81EF32E");
    
    	/// <summary>
    	/// Indicates that the image was constructed from a memory bitmap.
    	/// </summary>
    	private static readonly Guid ImageFormatMemoryBMP = new Guid("B96B3CAB-0728-11D3-9D7B-0000F81EF32E");
    
    	/// <summary>
    	/// Indicates the Portable Network Graphics (PNG) format.
    	/// </summary>
    	private static readonly Guid ImageFormatPNG = new Guid("B96B3CAF-0728-11D3-9D7B-0000F81EF32E");
    
    	/// <summary>
    	/// Indicates the Tagged Image File Format (TIFF) format.
    	/// </summary>
    	private static readonly Guid ImageFormatTIFF = new Guid("B96B3CB1-0728-11D3-9D7B-0000F81EF32E");
    
    	/// <summary>
    	/// Indicates that Windows GDI+ is unable to determine the format.
    	/// </summary>
    	private static readonly Guid ImageFormatUndefined = new Guid("B96B3CA9-0728-11D3-9D7B-0000F81EF32E");
    
    	/// <summary>
    	/// Indicates the Windows Metafile Format (WMF) format.
    	/// </summary>
    	private static readonly Guid ImageFormatWMF = new Guid("B96B3CAD-0728-11D3-9D7B-0000F81EF32E");
    
    	internal const int S_OK = 0;
    
    	/// <summary>
    	/// Gets the ImageType of the given file
    	/// </summary>
    	/// <param name="fileName">Path of the file to get the info of</param>
    	/// <returns>ImageType of the given file</returns>
    	public static ImageType GetImageType(string fileName)
    	{
    		IImage imagingImage = null;
    		
    		try
    		{
    			if (File.Exists(fileName))
    			{
    				using (StreamOnFile fileStream = new StreamOnFile(fileName))
    				{
    					imagingImage = BitmapProperties.GetImage(fileStream);
    					if (imagingImage != null)
    					{
    						ImageInfo info = new ImageInfo();
    						uint ret = imagingImage.GetImageInfo(ref info);
    						if (ret == BitmapProperties.S_OK)
    						{
    							if (info.RawDataFormat == BitmapProperties.ImageFormatBMP)
    							{
    								return ImageType.BMP;
    							}
    							else if (info.RawDataFormat == BitmapProperties.ImageFormatEMF)
    							{
    								return ImageType.EMF;
    							}
    							else if (info.RawDataFormat == BitmapProperties.ImageFormatEXIF)
    							{
    								return ImageType.EXIF;
    							}
    							else if (info.RawDataFormat == BitmapProperties.ImageFormatGIF)
    							{
    								return ImageType.GIF;
    							}
    							else if (info.RawDataFormat == BitmapProperties.ImageFormatIcon)
    							{
    								return ImageType.Icon;
    							}
    							else if (info.RawDataFormat == BitmapProperties.ImageFormatJPEG)
    							{
    								return ImageType.JPEG;
    							}
    							else if (info.RawDataFormat == BitmapProperties.ImageFormatMemoryBMP)
    							{
    								return ImageType.MemoryBMP;
    							}
    							else if (info.RawDataFormat == BitmapProperties.ImageFormatPNG)
    							{
    								return ImageType.PNG;
    							}
    							else if (info.RawDataFormat == BitmapProperties.ImageFormatTIFF)
    							{
    								return ImageType.TIFF;
    							}
    							else if (info.RawDataFormat == BitmapProperties.ImageFormatWMF)
    							{
    								return ImageType.WMF;
    							}
    						}
    					}
    				}
    			}
    
    			return ImageType.Undefined;
    		}
    		finally
    		{
    			if (imagingImage != null)
    			{
    				Marshal.ReleaseComObject(imagingImage);
    			}
    		}
    	}
    
    	private static IImage GetImage(StreamOnFile stream)
    	{
    		IImagingFactory factory = null;
    		try
    		{
    			factory = (IImagingFactory)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("327ABDA8-072B-11D3-9D7B-0000F81EF32E")));
    			if (factory != null)
    			{
    				IImage imagingImage;
    				uint result = factory.CreateImageFromStream(stream, out imagingImage);
    				if (result == BitmapProperties.S_OK)
    				{
    					return imagingImage;
    				}
    			}
    		}
    		catch (COMException)
    		{
    		}
    		catch (IOException)
    		{
    		}
    		finally
    		{
    			if (factory != null)
    			{
    				Marshal.ReleaseComObject(factory);
    			}
    		}
    
    		return null;
    	}
    }
