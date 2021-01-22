    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Security.Cryptography;
    
    namespace DataProtectionTest
    {
    	public partial class Form1 : Form
    	{
    		private static readonly byte[] entropy = { 1, 2, 3, 4, 1, 2, 3, 4 };
    		private string password;
    		public Form1()
    		{
    			InitializeComponent();
    		}
    
    		private void btnEncryptIt_Click(object sender, EventArgs e)
    		{
    			Byte[] pw = Encoding.Unicode.GetBytes(textBox1.Text);
    			Byte[] encryptedPw = ProtectedData.Protect(pw, entropy, DataProtectionScope.LocalMachine);
    			//password = Encoding.Unicode.GetString(encryptedPw);		
    			password = Convert.ToBase64String(encryptedPw);
    		}
    
    		private void btnDecryptIt_Click(object sender, EventArgs e)
    		{
    			//Byte[] pwBytes = Encoding.Unicode.GetBytes(password);
    			Byte[] pwBytes = Convert.FromBase64String(password);
    			try
    			{
    				Byte[] decryptedPw = ProtectedData.Unprotect(pwBytes, entropy, DataProtectionScope.LocalMachine);
    				string pw = Encoding.Unicode.GetString(decryptedPw);
    				textBox2.Text = pw;
    			}
    			catch (CryptographicException ce)
    			{
    				textBox2.Text = ce.Message;
    			}
    		}
    	}
    }
