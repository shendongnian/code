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
    
    	/// <summary>
    	/// A PixelFormatID value identifying the natural pixel format for an image source, see PixelFormat Values.  If the source does not have a preference, use PixelFormatDontCare. 
    	/// </summary>
    	public PixelFormatID PixelFormat;
    
    	/// <summary>
    	/// A UNIT value indicating the width, in pixels, of the image source.
    	/// </summary>
    	public uint Width;
    
    	/// <summary>
    	/// A UNIT value indicating the height, in pixels, of the image source.
    	/// </summary>
    	public uint Height;
    
    	/// <summary>
    	/// A UINT value indicating the preferred tile width, in pixels, for the image source.
    	/// </summary>
    	public uint TileWidth;
    
    	/// <summary>
    	/// A UINT value indicating the preferred tile height, in pixels, for the image source.
    	/// </summary>
    	public uint TileHeight;
    
    	/// <summary>
    	/// A double value indicating the horizontal resolution, in dots per inch, of the source image.
    	/// </summary>
    	public double Xdpi;
    
    	/// <summary>
    	/// A double value indicating the vertical resolution, in dots per inch, of the source image.
    	/// </summary>
    	public double Ydpi;
    
    	/// <summary>
    	/// A UINT value that describes the properties of the image source. This value is a combination of one or more values from the SinkFlags enumeration.
    	/// </summary>
    	public SinkFlags Flags;
    
    	#endregion
    }
    
    /// <summary>
    /// Represents the number of 100-nanosecond intervals since January 1, 1601. This structure is a 64-bit value. 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct FILETIME
    {
    	#region Fields
    
    	/// <summary>
    	/// Specifies the low 32 bits of the FILETIME. 
    	/// </summary>
    	public int dwLowDateTime;
    
    	/// <summary>
    	/// Specifies the high 32 bits of the FILETIME.
    	/// </summary>
    	public int dwHighDateTime;
    
    	#endregion
    }
    
    /// <summary>
    /// Specifies the attributes of a bitmap image. The BitmapData class is used by the LockBits and UnlockBits methods of the Bitmap class. 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct BitmapData
    {
    	#region Fields
    
    	/// <summary>
    	/// Gets or sets the pixel width of the Bitmap object. This can also be thought of as the number of pixels in one scan line.
    	/// </summary>
    	public int Width;
    
    	/// <summary>
    	///   	Gets or sets the pixel height of the Bitmap object. Also sometimes referred to as the number of scan lines.
    	/// </summary>
    	public int Height;
    
    	/// <summary>
    	/// Gets or sets the stride width (also called scan width) of the Bitmap object.
    	/// </summary>
    	public int Stride;
    
    	/// <summary>
    	/// Gets or sets the format of the pixel information in the Bitmap object that returned this BitmapData object.
    	/// </summary>
    	public PixelFormatID PixelFormat;
    
    	/// <summary>
    	/// Gets or sets the address of the first pixel data in the bitmap. This can also be thought of as the first scan line in the bitmap.
    	/// </summary>
    	public IntPtr Scan0;
    
    	/// <summary>
    	/// Reserved. Do not use.
    	/// </summary>
    	public IntPtr Reserved;
    
    	#endregion
    }
    
    /// <summary>
    /// Contains statistical information about an open storage, stream, or byte-array object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct STATSTG
    {
    	#region Fields
    
    	/// <summary>
    	/// Represents a pointer to a null-terminated string containing the name of the object described by this structure. 
    	/// </summary>
    	[MarshalAs(UnmanagedType.LPWStr)]
    	public string pwcsName;
    
    	/// <summary>
    	/// Indicates the type of storage object, which is one of the values from the STGTY enumeration.
    	/// </summary>
    	public int type;
    
    	/// <summary>
    	/// Specifies the size, in bytes, of the stream or byte array. 
    	/// </summary>
    	public long cbSize;
    
    	/// <summary>
    	/// Indicates the last modification time for this storage, stream, or byte array. 
    	/// </summary>
    	public FILETIME mtime;
    
    	/// <summary>
    	/// Indicates the creation time for this storage, stream, or byte array.
    	/// </summary>
    	public FILETIME ctime;
    
    	/// <summary>
    	/// Specifies the last access time for this storage, stream, or byte array. 
    	/// </summary>
    	public FILETIME atime;
    
    	/// <summary>
    	/// Indicates the access mode that was specified when the object was opened. 
    	/// </summary>
    	public int grfMode;
    
    	/// <summary>
    	/// Indicates the types of region locking supported by the stream or byte array. 
    	/// </summary>
    	public int grfLocksSupported;
    
    	/// <summary>
    	/// Indicates the class identifier for the storage object. 
    	/// </summary>
    	public Guid clsid;
    
    	/// <summary>
    	/// Indicates the current state bits of the storage object (the value most recently set by the IStorage::SetStateBits method). 
    	/// </summary>
    	public int grfStateBits;
    
    	/// <summary>
    	/// Reserved for future use. 
    	/// </summary>
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
    	/// <summary>
    	/// Reads a specified number of bytes from the stream object into memory starting at the current seek pointer. 
    	/// </summary>
    	/// <param name="pv">When this method returns, contains the data read from the stream. This parameter is passed uninitialized.</param>
    	/// <param name="cb">The number of bytes to read from the stream object.</param>
    	/// <param name="pcbRead">A pointer to a ULONG variable that receives the actual number of bytes read from the stream object.</param>
    	void Read([Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, int cb, IntPtr pcbRead);
    
    	/// <summary>
    	/// Writes a specified number of bytes into the stream object starting at the current seek pointer. 
    	/// </summary>
    	/// <param name="pv">The buffer to write this stream to. </param>
    	/// <param name="cb">The number of bytes to write to the stream. </param>
    	/// <param name="pcbWritten">On successful return, contains the actual number of bytes written to the stream object. If the caller sets this pointer to Zero, this method does not provide the actual number of bytes written. </param>
    	void Write([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, int cb, IntPtr pcbWritten);
    
    	/// <summary>
    	/// Changes the seek pointer to a new location relative to the beginning of the stream, to the end of the stream, or to the current seek pointer. 
    	/// </summary>
    	/// <param name="dlibMove">The displacement to add to dwOrigin. </param>
    	/// <param name="origin">The origin of the seek. The origin can be the beginning of the file, the current seek pointer, or the end of the file.</param>
    	/// <param name="plibNewPosition">On successful return, contains the offset of the seek pointer from the beginning of the stream.</param>
    	void Seek(long dlibMove, int origin, IntPtr plibNewPosition);
    
    	/// <summary>
    	/// Changes the size of the stream object.
    	/// </summary>
    	/// <param name="libNewSize">The new size of the stream as a number of bytes. </param>
    	void SetSize(long libNewSize);
    
    	/// <summary>
    	/// Copies a specified number of bytes from the current seek pointer in the stream to the current seek pointer in another stream. 
    	/// </summary>
    	/// <param name="pstm">A reference to the destination stream. </param>
    	/// <param name="cb">The number of bytes to copy from the source stream. </param>
    	/// <param name="pcbRead">On successful return, contains the actual number of bytes read from the source. </param>
    	/// <param name="pcbWritten">On successful return, contains the actual number of bytes written to the destination. </param>
    	void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten);
    
    	/// <summary>
    	/// Ensures that any changes made to a stream object that is open in transacted mode are reflected in the parent storage. 
    	/// </summary>
    	/// <param name="grfCommitFlags">A value that controls how the changes for the stream object are committed. </param>
    	void Commit(int grfCommitFlags);
    
    	/// <summary>
    	/// Discards all changes that have been made to a transacted stream since the last Commit call. 
    	/// </summary>
    	void Revert();
    
    	/// <summary>
    	/// Restricts access to a specified range of bytes in the stream. 
    	/// </summary>
    	/// <param name="libOffset">The byte offset for the beginning of the range. </param>
    	/// <param name="cb">The length of the range, in bytes, to restrict.</param>
    	/// <param name="lockType">The requested restrictions on accessing the range.</param>
    	void LockRegion(long libOffset, long cb, int lockType);
    
    	/// <summary>
    	/// Removes the access restriction on a range of bytes previously restricted with the LockRegion method. 
    	/// </summary>
    	/// <param name="libOffset">The byte offset for the beginning of the range. </param>
    	/// <param name="cb">The length, in bytes, of the range to restrict.</param>
    	/// <param name="lockType">The access restrictions previously placed on the range.</param>
    	void UnlockRegion(long libOffset, long cb, int lockType);
    
    	/// <summary>
    	/// Retrieves the <see cref="T:NativeMethods.STATSTG"></see> structure for this stream.
    	/// </summary>
    	/// <param name="pstatstg">When this method returns, contains a <see cref="T:NativeMethods.STATSTG"></see> structure that describes this stream object. This parameter is passed uninitialized.</param>
    	/// <param name="grfStatFlag">Members in the <see cref="T:NativeMethods.STATSTG"></see> structure that this method does not return, thus saving some memory allocation operations.</param>
    	void Stat(out STATSTG pstatstg, int grfStatFlag);
    
    	/// <summary>
    	/// Creates a new stream object with its own seek pointer that references the same bytes as the original stream. 
    	/// </summary>
    	/// <param name="ppstm">When this method returns, contains the new stream object. This parameter is passed uninitialized. </param>
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
    
    	/// <summary>
    	/// Specifies the x-coordinate of the upper-left corner of the rectangle.
    	/// </summary>
    	public int left;
    
    	/// <summary>
    	/// Specifies the y-coordinate of the upper-left corner of the rectangle.
    	/// </summary>
    	public int top;
    
    	/// <summary>
    	/// Specifies the x-coordinate of the lower-right corner of the rectangle. 
    	/// </summary>
    	public int right;
    
    	/// <summary>
    	/// Specifies the y-coordinate of the lower-right corner of the rectangle.
    	/// </summary>
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
    	/// <summary>
    	/// Is an indexes into a palette.
    	/// </summary>
    	PixelFormatIndexed = 0x00010000,
    
    	/// <summary>
    	/// Is a GDI-supported format.
    	/// </summary>
    	PixelFormatGDI = 0x00020000,
    
    	/// <summary>
    	/// Has an alpha component.
    	/// </summary>
    	PixelFormatAlpha = 0x00040000,
    
    	/// <summary>
    	/// Is the pre-multiplied alpha.
    	/// </summary>
    	PixelFormatPAlpha = 0x00080000,
    
    	/// <summary>
    	/// Is extended color 16 bits/channel.
    	/// </summary>
    	PixelFormatExtended = 0x00100000,
    
    	/// <summary>
    	/// Is in canonical format.
    	/// </summary>
    	PixelFormatCanonical = 0x00200000,
    
    	/// <summary>
    	/// Is in an undefined format.
    	/// </summary>
    	PixelFormatUndefined = 0,
    
    	/// <summary>
    	/// Is the 1 bit-per-pixel indexed color bitmap.
    	/// </summary>
    	PixelFormat1bppIndexed = (1 | (1 << 8) | PixelFormatIndexed | PixelFormatGDI),
    
    	/// <summary>
    	/// Is 4bpp indexed color.
    	/// </summary>
    	PixelFormat4bppIndexed = (2 | (4 << 8) | PixelFormatIndexed | PixelFormatGDI),
    
    	/// <summary>
    	/// Is 16bpp grayscale.
    	/// </summary>
    	PixelFormat16bppGrayScale = (4 | (16 << 8) | PixelFormatExtended),
    
    	/// <summary>
    	/// Is 8bpp indexed color.
    	/// </summary>
    	PixelFormat8bppIndexed = (3 | (8 << 8) | PixelFormatIndexed | PixelFormatGDI),
    
    	/// <summary>
    	/// Is 16bpp RGB 5-5-5 (blue in low-order bits).
    	/// </summary>
    	PixelFormat16bppRGB555 = (5 | (16 << 8) | PixelFormatGDI),
    
    	/// <summary>
    	/// Is 16bpp RGB 5-6-5.
    	/// </summary>
    	PixelFormat16bppRGB565 = (6 | (16 << 8) | PixelFormatGDI),
    
    	/// <summary>
    	/// Is 16bpp ARGB 1-5-5-5.
    	/// </summary>
    	PixelFormat16bppARGB1555 = (7 | (16 << 8) | PixelFormatAlpha | PixelFormatGDI),
    
    	/// <summary>
    	/// Is 24bpp RGB (blue in low-order byte).
    	/// </summary>
    	PixelFormat24bppRGB = (8 | (24 << 8) | PixelFormatGDI),
    
    	/// <summary>
    	/// Is 32bpp RGB (high order byte unused)
    	/// </summary>
    	PixelFormat32bppRGB = (9 | (32 << 8) | PixelFormatGDI),
    
    	/// <summary>
    	/// Is 32bpp ARGB, non-premultiplied alpha.
    	/// </summary>
    	PixelFormat32bppARGB = (10 | (32 << 8) | PixelFormatAlpha | PixelFormatGDI | PixelFormatCanonical),
    
    	/// <summary>
    	/// Is 32bpp ARGB, premultiplied alpha.
    	/// </summary>
    	PixelFormat32bppPARGB = (11 | (32 << 8) | PixelFormatAlpha | PixelFormatPAlpha | PixelFormatGDI),
    
    	/// <summary>
    	/// Is 48bpp RGB.
    	/// </summary>
    	PixelFormat48bppRGB = (12 | (48 << 8) | PixelFormatExtended),
    
    	/// <summary>
    	/// Is 64bpp ARGB, non-premultiplied alpha
    	/// </summary>
    	PixelFormat64bppARGB = (13 | (64 << 8) | PixelFormatAlpha | PixelFormatCanonical | PixelFormatExtended),
    
    	/// <summary>
    	/// Is 64bpp ARGB, premultiplied alpha.
    	/// </summary>
    	PixelFormat64bppPARGB = (14 | (64 << 8) | PixelFormatAlpha | PixelFormatPAlpha | PixelFormatExtended),
    
    	/// <summary>
    	/// The underlying value of this macro can be used literally as the upper bound of a loop through all the other pixel formats.
    	/// </summary>
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
    
    	/// <summary>
    	/// Reads a specified number of bytes from the stream object into memory starting at the current seek pointer. 
    	/// </summary>
    	/// <param name="pv">When this method returns, contains the data read from the stream. This parameter is passed uninitialized.</param>
    	/// <param name="cb">The number of bytes to read from the stream object.</param>
    	/// <param name="pcbRead">A pointer to a ULONG variable that receives the actual number of bytes read from the stream object.</param>
    	public void Read(byte[] pv, int cb, IntPtr pcbRead)
    	{
    		int val = this.stream.Read(pv, 0, cb);
    		if (pcbRead != IntPtr.Zero)
    		{
    			Marshal.WriteInt32(pcbRead, val);
    		}
    	}
    
    	/// <summary>
    	/// Writes a specified number of bytes into the stream object starting at the current seek pointer. 
    	/// </summary>
    	/// <param name="pv">The buffer to write this stream to. </param>
    	/// <param name="cb">The number of bytes to write to the stream. </param>
    	/// <param name="pcbWritten">On successful return, contains the actual number of bytes written to the stream object. If the caller sets this pointer to Zero, this method does not provide the actual number of bytes written. </param>
    	public void Write(byte[] pv, int cb, IntPtr pcbWritten)
    	{
    		this.stream.Write(pv, 0, cb);
    		if (pcbWritten != IntPtr.Zero)
    		{
    			Marshal.WriteInt32(pcbWritten, cb);
    		}
    	}
    
    	/// <summary>
    	/// Changes the seek pointer to a new location relative to the beginning of the stream, to the end of the stream, or to the current seek pointer. 
    	/// </summary>
    	/// <param name="dlibMove">The displacement to add to dwOrigin. </param>
    	/// <param name="origin">The origin of the seek. The origin can be the beginning of the file, the current seek pointer, or the end of the file.</param>
    	/// <param name="plibNewPosition">On successful return, contains the offset of the seek pointer from the beginning of the stream.</param>
    	public void Seek(long dlibMove, int origin, IntPtr plibNewPosition)
    	{
    		long val = this.stream.Seek(dlibMove, (SeekOrigin)origin);
    		if (plibNewPosition != IntPtr.Zero)
    		{
    			Marshal.WriteInt64(plibNewPosition, val);
    		}
    	}
    
    	/// <summary>
    	/// Changes the size of the stream object.
    	/// </summary>
    	/// <param name="libNewSize">The new size of the stream as a number of bytes. </param>
    	public void SetSize(long libNewSize)
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	/// <summary>
    	/// Copies a specified number of bytes from the current seek pointer in the stream to the current seek pointer in another stream. 
    	/// </summary>
    	/// <param name="pstm">A reference to the destination stream. </param>
    	/// <param name="cb">The number of bytes to copy from the source stream. </param>
    	/// <param name="pcbRead">On successful return, contains the actual number of bytes read from the source. </param>
    	/// <param name="pcbWritten">On successful return, contains the actual number of bytes written to the destination. </param>
    	public void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	/// <summary>
    	/// Ensures that any changes made to a stream object that is open in transacted mode are reflected in the parent storage. 
    	/// </summary>
    	/// <param name="grfCommitFlags">A value that controls how the changes for the stream object are committed. </param>
    	public void Commit(int grfCommitFlags)
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	/// <summary>
    	/// Discards all changes that have been made to a transacted stream since the last Commit call. 
    	/// </summary>
    	public void Revert()
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	/// <summary>
    	/// Restricts access to a specified range of bytes in the stream. 
    	/// </summary>
    	/// <param name="libOffset">The byte offset for the beginning of the range. </param>
    	/// <param name="cb">The length of the range, in bytes, to restrict.</param>
    	/// <param name="lockType">The requested restrictions on accessing the range.</param>
    	public void LockRegion(long libOffset, long cb, int lockType)
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	/// <summary>
    	/// Removes the access restriction on a range of bytes previously restricted with the LockRegion method. 
    	/// </summary>
    	/// <param name="libOffset">The byte offset for the beginning of the range. </param>
    	/// <param name="cb">The length, in bytes, of the range to restrict.</param>
    	/// <param name="lockType">The access restrictions previously placed on the range.</param>
    	public void UnlockRegion(long libOffset, long cb, int lockType)
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	/// <summary>
    	/// Retrieves the <see cref="T:NativeMethods.STATSTG"></see> structure for this stream.
    	/// </summary>
    	/// <param name="pstatstg">When this method returns, contains a <see cref="T:NativeMethods.STATSTG"></see> structure that describes this stream object. This parameter is passed uninitialized.</param>
    	/// <param name="grfStatFlag">Members in the <see cref="T:NativeMethods.STATSTG"></see> structure that this method does not return, thus saving some memory allocation operations.</param>
    	public void Stat(out STATSTG pstatstg, int grfStatFlag)
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	/// <summary>
    	/// Creates a new stream object with its own seek pointer that references the same bytes as the original stream. 
    	/// </summary>
    	/// <param name="ppstm">When this method returns, contains the new stream object. This parameter is passed uninitialized. </param>
    	public void Clone(out IStream ppstm)
    	{
    		throw new NotImplementedException("The method or operation is not implemented.");
    	}
    
    	/// <summary>
    	/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    	/// </summary>
    	/// <filterpriority>2</filterpriority>
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
    	/// Indic
