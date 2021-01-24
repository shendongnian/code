    StringBuilder sb = new StringBuilder();
    
    foreach(string s in ListOfElement) 
    {
        sb.Append(s);
    }
    
    hashDataList = BitConverter.ToString   (new System.Security.Cryptography.SHA512CryptoServiceProvider()
                               .ComputeHash(Encoding.UTF8.GetBytes(sb.ToString()))).Replace("-", String.Empty).ToUpper();
    
    Console.WriteLine("Hash: "+hashDataList);
