     protected void m_GenerateSHA256_Button1_Click(objectSender, EventArgs e)
    {
    string salt =createSalt(10);
    string hashedPassword=GenerateSHA256Hash(m_UserInput_TextBox.Text,Salt);
    m_SaltHash_TextBox.Text=Salt;
     m_SaltSHA256Hash_TextBox.Text=hashedPassword;
    }
     public string createSalt(int size)
    {
     var rng= new System.Security.Cyptography.RNGCyptoServiceProvider();
     var buff= new byte[size];
    rng.GetBytes(buff);
     return Convert.ToBase64String(buff);
    }
     public string GenerateSHA256Hash(string input,string salt)
    {
     byte[]bytes=System.Text.Encoding.UTF8.GetBytes(input+salt);
     new System.Security.Cyptography.SHA256Managed();
     byte[]hash=sha256hashString.ComputedHash(bytes);
     return bytesArrayToHexString(hash);
      }
