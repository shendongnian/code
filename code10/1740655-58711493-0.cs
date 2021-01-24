    public class MainWindow
    {
        private readonly HttpListener _httpListener;
        public MainWindow()
        {
            _httpListener = new HttpListener();
            _httpListener.Prefixes.Add("http://*:9191/");
            Task.Run(Start);
        }
        public async Task Start()
        {
            _httpListener.Start();
            while (true)
            {
                var context = await _httpListener.GetContextAsync();
                using (var sw = new StreamWriter(context.Response.OutputStream))
                {
                    await sw.FlushAsync();
                }
            }
        }
    }
