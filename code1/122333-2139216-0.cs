    using System;
    using System.Text;
    using System.Security.Cryptography;
    using System.IO;
    using System.Net.WebClient;
    public string GenerateMD5(string plaintext)
    {
        Byte[] _originalBytes;
        Byte[] _encodedBytes;
        MD5 _md5;
    
        _md5 = new MD5CryptoServiceProvider();
        _originalBytes = ASCIIEncoding.Default.GetBytes(plaintext);
        _encodedBytes = _md5.ComputeHash(_originalBytes);
    
      return BitConverter.ToString(_encodedBytes).ToLower();
    }
    
    public string file_get_contents(string url) 
    { 
        string sContents = string.Empty; 
    
        if (url.ToLower().IndexOf("http:") > -1) {
            System.Net.WebClient wc = new System.Net.WebClient(); 
            byte[] response = wc.DownloadData(url); 
            sContents = System.Text.Encoding.ASCII.GetString(response); 
        } else { 
            System.IO.StreamReader sr = new System.IO.StreamReader(url); 
            sContents = sr.ReadToEnd(); 
            sr.Close(); 
        } 
    
        return sContents;
    }
    
    public bool hasGravatar(string email)
    {
        string _mailMD5 = GenerateMD5(email);
        string _url = String.Format("http://www.gravatar.com/avatar/{0}?default=identicon&size=32", _mailMD5);
        string _fileMD5 = GenerateMD5(file_get_contents(_url));
    
        return !(_fileMD5 == "02dcccdb0707f1c5acc9a0369ac24dac");
    }
