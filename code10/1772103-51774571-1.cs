    using System.Diagnostics;
    using System.Text;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Controls;
    
    namespace Question_Answer_UWPApp
    {
        public sealed partial class MainPage : Page
        {
            public static Stopwatch stopwatch = new Stopwatch();
            public MainPage()
            {
                InitializeComponent();
                AddTextAsynchronously();
            }
    
            public async void AddTextAsynchronously()
            {            
                progressBarAddingText.IsEnabled = true;
    
                var text = await Task.Run(() =>
                {
                    var stringBuilder = new StringBuilder();
                    for (int i = 0; i < 5000; i++)
                        stringBuilder.Append("X");
    
                    return stringBuilder.ToString();
                });
    
                stopwatch.Start();
    
                textBlockAddingTextTime.Text = $"{stopwatch.ElapsedMilliseconds.ToString()} milliseconds";
    
                stopwatch.Stop();
                textBoxAddingText.Text = text;
                progressBarAddingText.IsEnabled = false;
            }
        }
    }
