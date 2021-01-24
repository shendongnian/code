    public partial class TestingForm : Form
    {
    
        public TestingForm()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            var completed = 0;
            var callback = new Action<String, Exception>((r, ex) =>
            {
                Interlocked.Increment(ref completed);
                Console.WriteLine(completed);
            });
    
            for (int i = 0; i < 10000; i++)
            {
                var req = HttpWebRequest.Create("http://example.com");
                req.Proxy = new WebProxy("127.0.0.2:8888");
                WebHelper.BeginGetResponse(req, callback);
            }
        }
    }
