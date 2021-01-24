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
            }
    
            public async void AddTextAsynchronously()
            { 
                var text = await Task.Run(() =>
                {
                    var stringBuilder = new StringBuilder();
    
                    for (int i = 0; i < 5000; i++)
                        stringBuilder.Append("X");
    
                    return stringBuilder.ToString();
                });
    
                stopwatch.Start();
    
                textBoxAddingText.Text = text;
    
                stopwatch.Stop();
                textBlockAddingTextTime.Text = $"{stopwatch.ElapsedMilliseconds.ToString()} milliseconds";
            }
    
            private void ButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
            {
                AddTextAsynchronously();
            }
        }
    }
