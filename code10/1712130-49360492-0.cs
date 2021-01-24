      public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string fileName = "", fileExt = "", FullPath = "";
        WSQEncoder ws = new WSQEncoder();
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "JPEG files (*.jpg)|*.jpg|BMP files (*.bmp)|*.bmp|PNG files (*.png)|*.png";
                dialog.Title = "Select a JPEG/PNG/BMP file";
                dialog.Multiselect = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FullPath = dialog.FileName;
                    string[] ext = dialog.FileName.Split('.');
                    pictureBox1.Image = new Bitmap(dialog.FileName);
                    fileExt = ext[1].ToString();
                    fileName = System.IO.Path.GetFileName(dialog.FileName);
                    txtOutputLocation.Text = "D:\\" + fileName.Replace(fileExt, "wsq");
                    if (fileExt.ToUpper() == "PNG")
                        cbFileType.SelectedIndex = 2;
                    else if (fileExt.ToUpper() == "BMP")
                        cbFileType.SelectedIndex = 1;
                    else
                        cbFileType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            txtOutputLocation.Text = string.Empty;
            cbFileType.SelectedIndex = 0;
        }
        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbFileType.SelectedIndex < 0)
                {
                    MessageBox.Show("Select an Image", "Image Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtOutputLocation.Text == "" || FullPath == "")
                {
                    MessageBox.Show("Select an Image", "Image Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "WSQ file(*.wsq)|*.wsq";
                saveFileDialog1.Title = "Save a WSQ File";
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {
                    //wsq.IMGtoWSQ(cbFileType.SelectedItem.ToString(), FullPath, txtOutputLocation.Text);
                    string msg = ws.IMGtoWSQ(cbFileType.SelectedItem.ToString(), FullPath, saveFileDialog1.FileName.ToString());
                    MessageBox.Show("Response Status : " + msg, "Conversion Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (msg == "YES")
                        btnClear_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
