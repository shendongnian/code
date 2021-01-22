    private void cmdDeriveKey_Click(object sender, EventArgs e)
            {
                byte[] salt = ASCIIEncoding.UTF8.GetBytes(txtSalt.Text);
    
                PBKDF2 passwordDerive = new PBKDF2();
                
          // I want the key to be used for AES-128, thus I want the derived key to be
          // 128 bits. Thus I will be using 128/8 = 16 for dkLen (Derived Key Length) . 
          //Similarly if you wanted a 256 bit key, dkLen would be 256/8 = 32. 
                byte[] result = passwordDerive.GenerateDerivedKey(16, ASCIIEncoding.UTF8.GetBytes(txtPassword.Text), salt, 1000);
    
               //result would now contain the derived key. Use it for whatever cryptographic purpose now :)
               //The following code is ONLY to show the derived key in a Textbox.
                string x = "";
    
                for (int i = 0; i < result.Length; i++)
                {
                    x += result[i].ToString("X");
                }
    
                txtResult.Text = x;
    
            }
