    using System;
    using System.Windows.Forms;
    using System.Security.Cryptography;
    namespace ExampleCrypto
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                string strOriginalData = string.Empty;
                string strEncryptedData = string.Empty;
                string strDecryptedData = string.Empty;
                strOriginalData = "this is original data 1234567890"; // your original data in here
                MessageBox.Show("ORIGINAL DATA:\r\n" + strOriginalData);
                clsCrypto aes = new clsCrypto();
                aes.IV = "this is your IV";     // your IV
                aes.KEY = "this is your KEY";    // your KEY      
                strEncryptedData = aes.Encrypt(strOriginalData, CipherMode.CBC);    // your cipher mode
                MessageBox.Show("ENCRYPTED DATA:\r\n" + strEncryptedData);
                strDecryptedData = aes.Decrypt(strEncryptedData, CipherMode.CBC);
                MessageBox.Show("DECRYPTED DATA:\r\n" + strDecryptedData);
            }
        }
    }
