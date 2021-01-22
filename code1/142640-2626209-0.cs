    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Security.Cryptography.X509Certificates;
    using System.IO;
    
    namespace LargeCMS
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                subjectTextBox.Text = "ALEX";
                originalTextBox.Text = "my1GBfile.txt";
                encodedTextBox.Text = "encodeddata.p7s";
                decodedTextBox.Text = "decodeddata.txt";
            }
    
            private void encodeButton_Click(object sender, EventArgs e)
            {
                // Variables
                X509Store store = null;
                X509Certificate2 cert = null;
                FileStream inFile = null;
                FileStream outFile = null;
                CMS cms = null;
    
                try
                {
                    // Get user cert
                    store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                    store.Open(OpenFlags.MaxAllowed);
                    cert = store.Certificates.Find(X509FindType.FindBySubjectName, subjectTextBox.Text, true)[0];
    
                    // Open file with data to encode
                    inFile = File.Open(originalTextBox.Text, FileMode.Open);
    
                    // Create file for encoded data
                    outFile = File.Create(encodedTextBox.Text);
    
                    // Encode data
                    cms = new CMS();
                    cms.Encode(cert, inFile, outFile);
    
                    MessageBox.Show("Sucess!!!");
                }
                catch (Exception ex)
                {
                    // Show errors
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show(ex.Message + "\n" + ex.InnerException.Message);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                finally
                {
                    // Clean up
                    if (store != null) { store.Close(); }
                    if (inFile != null) { inFile.Close(); }
                    if (outFile != null) { outFile.Close(); }
                }
            }
    
            private void decodeButton_Click(object sender, EventArgs e)
            {
                // Variables
                FileStream inFile = null;
                FileStream outFile = null;
                CMS cms = null;
    
                try
                {
                    // Open file with data to decode
                    inFile = File.Open(encodedTextBox.Text, FileMode.Open);
    
                    // Create file for encoded data
                    outFile = File.Create(decodedTextBox.Text);
    
                    // Decode data
                    cms = new CMS();
                    cms.Decode(inFile, outFile);
    
                    MessageBox.Show("Sucess!!!");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        MessageBox.Show(ex.Message + "\n" + ex.InnerException.Message);
                    }
                    else
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                finally
                {
                    // Clean up
                    if (inFile != null) { inFile.Close(); }
                    if (outFile != null) { outFile.Close(); }
                }
    
            }
        }
    }
 
