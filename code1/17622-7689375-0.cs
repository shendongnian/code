    using System;  
    using System.Collections.Generic;  
    using System.Linq;  
    using System.Text;  
    using System.IO.Packaging;  
    using System.IO;  
    
    public class ZipSticle  
    {  
        Package package;  
      
        public ZipSticle(Stream s)  
        {  
            package = ZipPackage.Open(s, FileMode.Create);  
        }  
      
        public void Add(Stream stream, string Name)  
        {  
            Uri partUriDocument = PackUriHelper.CreatePartUri(new Uri(Name, UriKind.Relative));  
            PackagePart packagePartDocument = package.CreatePart(partUriDocument, "");  
      
            CopyStream(stream, packagePartDocument.GetStream());  
            stream.Close();  
        }  
      
        private static void CopyStream(Stream source, Stream target)  
        {  
            const int bufSize = 0x1000;  
            byte[] buf = new byte[bufSize];  
            int bytesRead = 0;  
            while ((bytesRead = source.Read(buf, 0, bufSize)) > 0)  
                target.Write(buf, 0, bytesRead);  
        }  
      
        public void Close()  
        {  
            package.Close();  
        }  
    }
