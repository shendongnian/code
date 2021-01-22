    using PdfLib;
    namespace WindowsFormsApplication1{
    public partial class ViewerForm : Form{
        public ViewerForm()
        {
         InitializeComponent();
         PdfLib.AxAcroPDF axAcroPDF1;
         axAcroPDF1.LoadFile(@"C:\Documents and Settings\jcrowe\Desktop\Medical Gas\_0708170240_001.pdf");
         axAcroPDF1.Show(); }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {   } } }
 
