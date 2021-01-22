    using System.Security.Cryptography;
    using System.Text;
    using System.Drawing.Imaging;
    // ...
    
    // get the bytes from the image
    byte[] bytes = null;
    using( MemoryStream ms = new MemoryStream() )
    {
        image.Save(ms,ImageFormat.Gif); // gif for example
        bytes =  ms.ToArray();
    }
    
    // hash the bytes
    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
    byte[] hash = md5.ComputeHash(bytes);
    
    // make a hex string of the hash for display or whatever
    StringBuilder sb = new StringBuilder();
    foreach (byte b in bytes)
    {
       sb.Append(b.ToString("x2").ToLower());
    } 
