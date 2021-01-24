    public class Grade 
    {
       public string ImageName { get; set; }
       public BitmapSource ImageSource => BitmapImage(new Uri($"pack://application:,,,/AssemblyName;component/{ImageName}")); 
    }
