        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.webBrowser1.DocumentText = @"<html>
    <body>
    <script type = ""text/javascript"">
    function ShowMessage(text) {
       alert(text);
    }
    </script>
    </body>
    <input type=""button"" onclick=""ShowMessage('From JavaScript')"" value=""Click me""/>
    </html>";
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                this.webBrowser1.Document.InvokeScript("ShowMessage",new object[]{"From C#"});
            }
        }
