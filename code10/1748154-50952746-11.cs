    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    namespace WpfApp2.Behaviors
    {
    	public class TextBoxExtensions
    	{
    		public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached(
    			"Watermark",
    			typeof(string),
    			typeof(TextBoxExtensions),
    			new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, OnWatermarkTextChanged)
    		);
    
    		private static void OnWatermarkTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    		{
    			var tb = d as TextBox;
    
    			if (tb != null)
    			{
    				var textChangedHandler = new TextChangedEventHandler((s, ea) => ShowOrHideWatermark(s as TextBox));
    				var focusChangedHandler = new DependencyPropertyChangedEventHandler((s, ea) => ShowOrHideWatermark(s as TextBox));
    				var sizeChangedHandler = new SizeChangedEventHandler((s, ea) => ShowOrHideWatermark(s as TextBox));
    
    				if (string.IsNullOrEmpty(e.OldValue as string))
    				{
    					tb.TextChanged += textChangedHandler;
    					tb.IsKeyboardFocusedChanged += focusChangedHandler;
    					// subscribe to SizeChanged events in substitution for FontSize change events
    					tb.SizeChanged += sizeChangedHandler;
    				}
    
    				if (string.IsNullOrEmpty(e.NewValue as string))
    				{
    					tb.TextChanged -= textChangedHandler;
    					tb.IsKeyboardFocusedChanged -= focusChangedHandler;
    					tb.SizeChanged -= sizeChangedHandler;
    				}
    
    				ShowOrHideWatermark(tb);
    			}
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
    			if (string.IsNullOrEmpty(tb.Text) && !tb.IsKeyboardFocused)
    			{
    				var wm = GetWatermark(tb);
    				if (!string.IsNullOrEmpty(wm))
    				{
    					//System.Diagnostics.Debug.WriteLine($"Creating watermark background {wm} with font size {tb.FontSize}");
    					tb.Background = CreateTextBrush(wm, tb.FontSize);
    				}
    				else
    				{
    					tb.Background = null;
    				}
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
