    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
 
    namespace ConsoleRedirection
    {
        public partial class FormConsole : Form
        {
            // That's our custom TextWriter class
            TextWriter _writer = null;
 
            public FormConsole()
            {
                InitializeComponent();
            }
 
            private void FormConsole_Load(object sender, EventArgs e)
            {
                 // Instantiate the writer
                 _writer = new TextBoxStreamWriter(txtConsole);
                 // Redirect the out Console stream
                Console.SetOut(_writer);
 
                Console.WriteLine("Now redirecting output to the text box");
            }
 
            // This is called when the "Say Hello" button is clicked
            private void txtSayHello_Click(object sender, EventArgs e)
            {
                // Writing to the Console now causes the text to be displayed in the text box.
                Console.WriteLine("Hello world");
            }
        }
    }
