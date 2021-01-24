    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void button1_Click( object sender, EventArgs e )
        {
            button1.Enabled = false;
            label1.Text = "acquire files ...";
            ICollection<string> acquiredFiles = await AcquireFileAsync();
            label1.Text = "select files ...";
            ICollection<string> selectedFiles = SelectFilesDialog( acquiredFiles );
            label1.Text = "process files ...";
            await ProcessFilesAsync( selectedFiles );
            label1.Text = "finished.";
            button1.Enabled = true;
        }
        private async Task ProcessFilesAsync( ICollection<string> selectedFiles )
        {
            foreach (var item in selectedFiles)
            {
                await Task.Delay( 250 ).ConfigureAwait( false );
            }
        }
        private ICollection<string> SelectFilesDialog( ICollection<string> acquiredFiles )
        {
            var dialog = new Form2();
            dialog.ShowDialog();
            return acquiredFiles;
        }
        private async Task<ICollection<string>> AcquireFileAsync()
        {
            await Task.Delay( 2500 ).ConfigureAwait( false );
            return Enumerable.Range( 1, 20 ).Select( e => e.ToString() ).ToList();
        }
    }
