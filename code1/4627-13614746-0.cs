    public class MimeType
    {
        private static readonly byte[] BMP = { 66, 77 };
        private static readonly byte[] DOC = { 208, 207, 17, 224, 161, 177, 26, 225 };
        private static readonly byte[] EXEDLL = { 77, 90 };
        private static readonly byte[] GIF = { 71, 73, 70, 56 };
        private static readonly byte[] JPG = { 255, 216, 255 };
        private static readonly byte[] PNG = { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82 };
        private static readonly byte[] PDF = { 37, 80, 68, 70, 45, 49, 46 };
        private static readonly byte[] TIFF = { 73, 73, 42, 0 };
        private static readonly byte[] ZIP = { 80, 75, 3, 4 };
        
    
        public static string GetMimeType(byte[] file)
        {
            string fileText = Encoding.UTF8.GetString(file);
    
            string mime;
    
            if (file.Take(7).SequenceEqual(PDF))
            {
                mime = "application/pdf";
            }
            else if (file.Take(2).SequenceEqual(BMP))
            {
                mime = "image/bmp";
            }
            else if (file.Take(2).SequenceEqual(EXEDLL))
            {
                mime = "application/x-msdownload";
            }
            else if (file.Take(8).SequenceEqual(DOC))
            {
                mime = "application/msword";
            }
            else if (fileText.Substring(0, 80).Contains("[Content_Types].xml")) //DOCX
            {
                mime = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            }
            else if (file.Take(4).SequenceEqual(ZIP))
            {
                mime = "application/x-zip-compressed";
            }
            else if (file.Take(16).SequenceEqual(PNG))
            {
                mime = "image/png";
            }
            else if (file.Take(3).SequenceEqual(JPG))
            {
                mime = "image/jpeg";
            }
            else if (file.Take(4).SequenceEqual(GIF))
            {
                mime = "image/gif";
            }
            else if (file.Take(4).SequenceEqual(TIFF))
            {
                mime = "image/tiff";
            }
            else //Unknown File Type
            {
                mime = "application/octet-stream";
            }
    
            return mime;
        }
    
    
    
    
    } 
