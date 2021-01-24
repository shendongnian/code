        class WebClientUtility : WebClient
		{
			public int Timeout { get; set; }
			public WebClientUtility() : this(60000) { }
			public WebClientUtility(int timeout)
			{
				this.Timeout = timeout;
			}
			protected override WebRequest GetWebRequest(Uri address)
			{
				var request = base.GetWebRequest(address);
				if (request != null)
				{
					request.Timeout = Timeout;
				}
				return request;
			}
		}
		
		//
		public class DownloadHelper : IDisposable
		{
			private WebClientUtility _webClient;
			private string _downloadUrl;
			private string _savePath;
			private int _retryCount;
			
			public DownloadHelper(string downloadUrl, string savePath)
			{
				_savePath = savePath;
				_downloadUrl = downloadUrl;
				_webClient = new WebClientUtility();
				_webClient.DownloadFileCompleted += ClientOnDownloadFileCompleted;
			}
			
			public void StartDownload()
			{
				_webClient.DownloadFileAsync(new Uri(_downloadUrl), _savePath);
			}
			
			private void ClientOnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
			{
				if (e.Error != null)
				{
					_retryCount++;
					if (_retryCount < 3)
					{
						_webClient.DownloadFileAsync(new Uri(_downloadUrl), _savePath);
					}
					else
					{
						Console.WriteLine(e.Error.Message);
					}
				}
				else
				{
					_retryCount = 0;
					Console.WriteLine($"successfully download: # {_downloadUrl}  to  # {_savePath}");
				}
			}
			public void Dispose()
			{
				_webClient.Dispose();
			}
		}
		
		//
		class Program
		{
			private static void Main(string[] args)
			{
				for (int i = 0; i < 100; i++)
				{
					var downloadUrl = $@"https://example.com/mag-{i}.pdf";
					var savePath = $@"D:\DownloadFile\FileName{i}.pdf";
					DownloadHelper downloadHelper = new DownloadHelper(downloadUrl, savePath);
					downloadHelper.StartDownload();
				}
				Console.ReadLine();
			}
		}
       
