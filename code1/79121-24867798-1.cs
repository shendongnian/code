    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Drawing.Drawing2D;
    namespace PhotoShrinker
    {
    class Program
    {
    /// <summary>
    /// Max photo size in bytes
    /// </summary>
    const long MAX_PHOTO_SIZE = 409600;
    static void Main(string[] args)
    {
        var photos = Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.jpg");
        foreach (var photo in photos)
        {
            var photoName = Path.GetFileNameWithoutExtension(photo);
            var fi = new FileInfo(photo);
            Console.WriteLine("Photo: " + photo);
            Console.WriteLine(fi.Length);
            if (fi.Length > MAX_PHOTO_SIZE)
            {
				using (var image = Image.FromFile(photo)) 
                {
                      using (var stream = DownscaleImage(image))
                      {
                            using (var file = File.Create(photoName + "-smaller.jpg"))
                            {
                                stream.CopyTo(file);
                            }
                      }
                }
                Console.WriteLine("File resized.");
            }
            Console.WriteLine("Done.")
            Console.ReadLine();
        }
    }
    private static MemoryStream DownscaleImage(Image photo)
    {
        MemoryStream resizedPhotoStream = new MemoryStream();
        long resizedSize = 0;
        var quality = 93;
        //long lastSizeDifference = 0;
        do
        {
            resizedPhotoStream.SetLength(0);
            EncoderParameters eps = new EncoderParameters(1);
            eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, (long)quality);
            ImageCodecInfo ici = GetEncoderInfo("image/jpeg");
            photo.Save(resizedPhotoStream, ici, eps);
            resizedSize = resizedPhotoStream.Length;
            //long sizeDifference = resizedSize - MAX_PHOTO_SIZE;
            //Console.WriteLine(resizedSize + "(" + sizeDifference + " " + (lastSizeDifference - sizeDifference) + ")");
            //lastSizeDifference = sizeDifference;
            quality--;
        } while (resizedSize > MAX_PHOTO_SIZE);
        resizedPhotoStream.Seek(0, SeekOrigin.Begin);
        return resizedPhotoStream;
    }
    private static ImageCodecInfo GetEncoderInfo(String mimeType)
    {
        int j;
        ImageCodecInfo[] encoders;
        encoders = ImageCodecInfo.GetImageEncoders();
        for (j = 0; j < encoders.Length; ++j)
        {
            if (encoders[j].MimeType == mimeType)
                return encoders[j];
        }
        return null;
    }
    }
    }
