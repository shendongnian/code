    using System.Linq;
    //...
    //get image
    var file_bytes = System.Convert.FromBase64String(@"iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==");
    var file_stream = new System.IO.MemoryStream(file_bytes);
    var file_image = System.Drawing.Image.FromStream(file_stream);
    //list image formats
    var image_formats = typeof(System.Drawing.Imaging.ImageFormat).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).ToList().ConvertAll(property => property.GetValue(null, null));
    System.Diagnostics.Debug.WriteLine(image_formats.Count, "image_formats");
    foreach(var image_format in image_formats) {
        System.Diagnostics.Debug.WriteLine(image_format, "image_formats");
    }
    //get image format
    var file_image_format = typeof(System.Drawing.Imaging.ImageFormat).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static).ToList().ConvertAll(property => property.GetValue(null, null)).Single(image_format => image_format.Equals(file_image.RawFormat));
    System.Diagnostics.Debug.WriteLine(file_image_format, "file_image_format");
    //list image codecs
    var image_codecs = System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders().ToList();
    System.Diagnostics.Debug.WriteLine(image_codecs.Count, "image_codecs");
    foreach(var image_codec in image_codecs) {
        System.Diagnostics.Debug.WriteLine(image_codec.CodecName + ", mime: " + image_codec.MimeType + ", extension: " + @image_codec.FilenameExtension, "image_codecs");
    }
    //get image codec
    var file_image_format_codec = System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders().ToList().Single(image_codec => image_codec.FormatID == file_image.RawFormat.Guid);
    System.Diagnostics.Debug.WriteLine(file_image_format_codec.CodecName + ", mime: " + file_image_format_codec.MimeType + ", extension: " + file_image_format_codec.FilenameExtension, "image_codecs", "file_image_format_type");
