    public class OpenFileDialogEx
    {
    	public static readonly DependencyProperty FilterProperty =
    	  DependencyProperty.RegisterAttached("Filter",
    		typeof (string),
    		typeof (OpenFileDialogEx),
    		new PropertyMetadata("All documents (.*)|*.*", (d, e) => AttachFileDialog((TextBox) d, e)));
    
    	public static string GetFilter(UIElement element)
    	{
    	  return (string)element.GetValue(FilterProperty);
    	}
    
    	public static void SetFilter(UIElement element, string value)
    	{
    	  element.SetValue(FilterProperty, value);
    	}
    
    	private static void AttachFileDialog(TextBox textBox, DependencyPropertyChangedEventArgs args)
    	{                  
    	  var parent = (Panel) textBox.Parent;
    
    	  parent.Loaded += delegate {
    		
    		var button = (Button) parent.Children.Cast<object>().FirstOrDefault(x => x is Button);
    
    		var filter = (string) args.NewValue;
    
    		button.Click += (s, e) => {
    		  var dlg = new OpenFileDialog();
    		  dlg.Filter = filter;
    
    		  var result = dlg.ShowDialog();
    
    		  if (result == true)
    		  {
    			textBox.Text = dlg.FileName;
    		  }
    
    		};
    	  };
    	}
    }
 
