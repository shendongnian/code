    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;
	public class TextBoxWatermarked : TextBox
	{
		#region [ Dependency Properties ]
		public static DependencyProperty WatermarkProperty = DependencyProperty.Register("Watermark",
																				 typeof(string),
																				 typeof(TextBoxWatermarked),
																				 new PropertyMetadata(new PropertyChangedCallback(OnWatermarkChanged)));
		
		#endregion
		
		
		#region [ Fields ]
		
		private bool _isWatermarked;
		private Binding _textBinding;
		#endregion
		#region [ Properties ]
		protected new Brush Foreground
		{
			get { return base.Foreground; }
			set { base.Foreground = value; }
		}
		public string Watermark
		{
			get { return (string)GetValue(WatermarkProperty); }
			set	{ SetValue(WatermarkProperty, value); }
		}
		#endregion
		#region [ .ctor ]
		
		public TextBoxWatermarked()
		{
			Loaded += (s, ea) => ShowWatermark();
		}
		
		#endregion
		#region [ Event Handlers ]
		protected override void OnGotFocus(RoutedEventArgs e)
		{
			base.OnGotFocus(e);
			HideWatermark();
		}
		
		protected override void OnLostFocus(RoutedEventArgs e)
		{
			base.OnLostFocus(e);
			ShowWatermark();
		}
		
		private static void OnWatermarkChanged(DependencyObject sender, DependencyPropertyChangedEventArgs ea)
		{
			var tbw = sender as TextBoxWatermarked;
			if (tbw == null) return;
			tbw.ShowWatermark();
		}
		#endregion
		#region [ Methods ]
		private void ShowWatermark()
		{
			if (string.IsNullOrEmpty(base.Text))
			{
				_isWatermarked = true;
				base.Foreground = new SolidColorBrush(Colors.Gray);
				var bindingExpression = GetBindingExpression(TextProperty);
				_textBinding = bindingExpression == null ? null : bindingExpression.ParentBinding;
				if (bindingExpression != null)
					bindingExpression.UpdateSource();
				SetBinding(TextProperty, new Binding());
				base.Text = Watermark;
			}
		}
		private void HideWatermark()
		{
			if (_isWatermarked)
			{
				_isWatermarked = false;
				ClearValue(ForegroundProperty);
				base.Text = "";
				SetBinding(TextProperty, _textBinding ?? new Binding());
			}
		}
		#endregion
	}
