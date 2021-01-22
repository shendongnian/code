    public class RichTextBoxHelper
    {
    private static readonly ILog m_Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    public static readonly DependencyProperty BindableSourceProperty =
        DependencyProperty.RegisterAttached("BindableSource", typeof(string), typeof(RichTextBoxHelper), new UIPropertyMetadata(null, BindableSourcePropertyChanged));
    public static string GetBindableSource(DependencyObject obj)
    {
      return (string)obj.GetValue(BindableSourceProperty);
    }
    public static void SetBindableSource(DependencyObject obj, string value)
    {
      obj.SetValue(BindableSourceProperty, value);
    }
    public static void BindableSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
      var thread = new Thread(
        () =>
        {
          try
          {
            var rtfBox = o as RichTextBox;
            var filename = e.NewValue as string;
            if (rtfBox != null && !string.IsNullOrEmpty(filename))
            {
              System.Windows.Application.Current.Dispatcher.Invoke(
                System.Windows.Threading.DispatcherPriority.Background,
                (Action)delegate()
                {
                  rtfBox.Selection.Load(new FileStream(filename, FileMode.Open), DataFormats.Rtf);
                });
            }
          }
          catch (Exception exception)
          {
            m_Logger.Error("RichTextBoxHelper ERROR : " + exception.Message, exception);
          }
        });
      thread.Start();
    }
    }
