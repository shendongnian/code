       using System;
       using System.Security.Cryptography;
       using System.Text;
       
       string sSourceData;
       byte[] tmpSource;
       byte[] tmpHash;
       
       sSourceData = "MySourceData";
       //Create a byte array from source data.
       tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
       
       //Compute hash based on source data.
       tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
