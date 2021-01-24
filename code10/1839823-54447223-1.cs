    using (var rng = new RNGCryptoServiceProvider())
    {
        byte[] password = new byte[10];
    	rng.GetBytes(password);
    	textBox11.Text = Convert.ToBase64String(password).Remove(13);
    }
