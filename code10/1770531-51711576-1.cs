    protected void Button1_Click(object sender, EventArgs e)
    {
        byte[] data = UTF8Encoding.UTF8.GetBytes(TextBox1.Text);
        using(MD5CryptoServiceProvider md5=new MD5CryptoServiceProvider())
        {
            byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
            using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider() {Key=keys,Mode=CipherMode.ECB,Padding=PaddingMode.PKCS7 })
            {
                ICryptoTransform transform=tripleDes.CreateEncryptor();
                byte[] results=transform.TransformFinalBlock(data,0,data.Length);
                Label1.Text = Convert.ToBase64String(results);
            }
        }
    }
