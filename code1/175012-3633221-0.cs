        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using Microsoft.Win32;
    using System.IO;
    using System.Windows.Interop;
    namespace System.Windows.Media.Imaging
    {
    public static class RewritableBitmap
    {
    public static WriteableBitmap ResizeWritableBitmap(this WriteableBitmap wBitmap,int reqWidth, int reqHeight)
    {
    int Stride = wBitmap.PixelWidth * ((wBitmap.Format.BitsPerPixel + 7) / 8);
    int NumPixels = Stride * wBitmap.PixelHeight;
    ushort[] ArrayOfPixels = new ushort[NumPixels];
     
     
    wBitmap.CopyPixels(ArrayOfPixels, Stride, 0);
     
    int OriWidth = (int) wBitmap.PixelWidth;
    int OriHeight = (int) wBitmap.PixelHeight;
     
    double nXFactor = (double)OriWidth / (double)reqWidth;
    double nYFactor = (double)OriHeight / (double)reqHeight;
     
    double fraction_x, fraction_y, one_minus_x, one_minus_y;
    int ceil_x, ceil_y, floor_x, floor_y;
     
    ushort pix1, pix2, pix3, pix4;
    int nStride = reqWidth * ((wBitmap.Format.BitsPerPixel + 7) / 8);
    int nNumPixels = reqWidth * reqHeight;
    ushort[] newArrayOfPixels = new ushort[nNumPixels];
    /*Core Part*/
                /* Code project article :
    Image Processing for Dummies with C# and GDI+ Part 2 - Convolution Filters By Christian Graus</a>
     
                href=<a href="http://www.codeproject.com/KB/GDI-plus/csharpfilters.aspx"></a>
                */
                for (int y = 0; y < reqHeight; y++)
    {
    for (int x = 0; x < reqWidth; x++)
    {
    // Setup
    floor_x = (int)Math.Floor(x * nXFactor);
    floor_y = (int)Math.Floor(y * nYFactor);
     
    ceil_x = floor_x + 1;
    if (ceil_x >= OriWidth) ceil_x = floor_x;
     
    ceil_y = floor_y + 1;
    if (ceil_y >= OriHeight) ceil_y = floor_y;
     
    fraction_x = x * nXFactor - floor_x;
    fraction_y = y * nYFactor - floor_y;
     
    one_minus_x = 1.0 - fraction_x;
    one_minus_y = 1.0 - fraction_y;
     
    pix1 = ArrayOfPixels[floor_x + floor_y * OriWidth];
    pix2 = ArrayOfPixels[ceil_x + floor_y * OriWidth];
    pix3 = ArrayOfPixels[floor_x + ceil_y * OriWidth];
    pix4 = ArrayOfPixels[ceil_x + ceil_y * OriWidth];
     
    ushort g1 = (ushort)(one_minus_x * pix1 + fraction_x * pix2);
    ushort g2 = (ushort)(one_minus_x * pix3 + fraction_x * pix4);
    ushort g = (ushort)(one_minus_y * (double)(g1) + fraction_y * (double)(g2));
    newArrayOfPixels[y * reqWidth + x] = g;
    }
    }
               /*End of Core Part*/
    WriteableBitmap newWBitmap = new WriteableBitmap(reqWidth, reqHeight, 96, 96, PixelFormats.Gray16, null);
    Int32Rect Imagerect = new Int32Rect(0, 0, reqWidth, reqHeight);
    int newStride = reqWidth * ((PixelFormats.Gray16.BitsPerPixel + 7) / 8);
    newWBitmap.WritePixels(Imagerect, newArrayOfPixels, newStride, 0);
    return newWBitmap;
    }
     
    }
    }
