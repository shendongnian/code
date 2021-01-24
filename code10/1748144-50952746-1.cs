    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace WpfApp2.Behaviors
    {
    	public class TextBoxExtensions : DependencyObject
    	{
    		public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached(
    			"Watermark",
    			typeof(string),
    			typeof(TextBoxExtensions),
    			new PropertyMetadata(null, OnWatermarkTextChanged)
    		);
    
    		private static void OnWatermarkTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    		{
    			var tb = d as TextBox;
    			tb.TextChanged += (s, args) => ShowOrHideWatermark(tb);
    			tb.IsKeyboardFocusedChanged += (s, args) => ShowOrHideWatermark(tb);
    			tb.SizeChanged += (s, args) => ShowOrHideWatermark(tb);
    			ShowOrHideWatermark(tb);
    		}
    
    		public static string GetWatermark(DependencyObject element)
    		{
    			return (string)element.GetValue(WatermarkProperty);
    		}
    
    		public static void SetWatermark(DependencyObject element, string value)
    		{
    			element.SetValue(WatermarkProperty, value);
    		}
    
    		private static void ShowOrHideWatermark(TextBox tb)
    		{
    			if(string.IsNullOrEmpty(tb.Text) && !tb.IsKeyboardFocused)
    			{
    				tb.Background = CreateTextBrush(GetWatermark(tb), tb.FontSize);
    			}
    			else
    			{
    				tb.Background = null;
    			}
    		}
    
    		private static Brush CreateTextBrush(string text, double fontSize)
    		{
    			Label label = new Label
    			{
    				Padding = new Thickness(2),
    				FontSize = fontSize,
    				Foreground = Brushes.LightGray,
    				Content = text
    			};
    
    			VisualBrush vb = new VisualBrush
    			{
    				Visual = label,
    				Stretch = Stretch.None,
    				AlignmentX = AlignmentX.Left,
    				AlignmentY = AlignmentY.Center
    			};
    
    			return vb;
    		}
    	}
    }
