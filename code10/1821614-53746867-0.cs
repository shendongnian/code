    public void SerializeUserConfig(string fileName)
    {
        try
        {
            Encrypt(userconfigstorage, Path.Combine(perfilAcesso.GetUserConfigPath(), fileName), "syndra15OP");
            MessageBox.Show("Dados salvos com sucesso!");
        }
        catch (Exception exception)
        {
            errorlog.SetError(exception.ToString());
            SerializeError(perfilAcesso.GetUserErrorLogPath());
            MessageBox.Show("Houve um erro ao salvar as configurações!\nPor favor, contate o desenvolvedor.\n\nEID: 002");
        }
    }
    
    public UserConfigStorage DeserializeUserConfig(string fileName)
    {
        return Decrypt(Path.Combine(perfilAcesso.GetUserConfigPath(), fileName), "syndra15OP");
    }
    
    public void Encrypt(UserConfigStorage input, string filePath, string strHash)
    {
        using (TripleDESCryptoServiceProvider tdc = new TripleDESCryptoServiceProvider())
        {
            using (FileStream outStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
    
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    tdc.Key = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strHash));
                    md5.Clear();
                }
    
                tdc.Mode = CipherMode.ECB;
    
                using (CryptoStream cryStream = new CryptoStream(outStream, tdc.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    BinaryFormatter binForm = new BinaryFormatter();
                    binForm.Serialize(cryStream, input);
                }
            }
        }
    }
    
    public UserConfigStorage Decrypt(string filePath, string strHash)
    {
        UserConfigStorage output;
    
        using (TripleDESCryptoServiceProvider tdc = new TripleDESCryptoServiceProvider())
        {
            using (FileStream outStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
    
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    tdc.Key = md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(strHash));
                    md5.Clear();
                }
    
                tdc.Mode = CipherMode.ECB;
    
                using (CryptoStream cryStream = new CryptoStream(outStream, tdc.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    BinaryFormatter binForm = new BinaryFormatter();
                    output = binForm.Deserialize(cryStream) as UserConfigStorage;
                }
            }
        }
    
        return output;
    }
