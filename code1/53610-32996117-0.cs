    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Interactivity;
    using System.Windows.Media;
    
    	public class HintBehavior : Behavior<ContentControl>
    	{
    		public static readonly DependencyProperty HintProperty = DependencyProperty
    			.Register("Hint", typeof (string), typeof (HintBehavior)
    			//, new FrameworkPropertyMetadata(null, OnHintChanged)
    			);
    
    		public string Hint
    		{
    			get { return (string) GetValue(HintProperty); }
    			set { SetValue(HintProperty, value); }
    		}
    
    		public static readonly DependencyProperty ValueProperty = DependencyProperty
    			.Register("Value", typeof (object), typeof (HintBehavior)
    				, new FrameworkPropertyMetadata(null, OnValueChanged));
    
    		private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    		{
    			var visible = e.NewValue == null;
    			d.SetValue(VisibilityProperty, visible ? Visibility.Visible : Visibility.Collapsed);
    		}
    
    		public object Value
    		{
    			get { return GetValue(ValueProperty); }
    			set { SetValue(ValueProperty, value); }
    		}
    
    		public static readonly DependencyProperty VisibilityProperty = DependencyProperty
    			.Register("Visibility", typeof (Visibility), typeof (HintBehavior)
    				, new FrameworkPropertyMetadata(Visibility.Visible
    					//, new PropertyChangedCallback(OnVisibilityChanged)
    					));
    
    		public Visibility Visibility
    		{
    			get { return (Visibility) GetValue(VisibilityProperty); }
    			set { SetValue(VisibilityProperty, value); }
    		}
    
    		public static readonly DependencyProperty ForegroundProperty = DependencyProperty
    			.Register("Foreground", typeof (Brush), typeof (HintBehavior)
    				, new FrameworkPropertyMetadata(new SolidColorBrush(Colors.DarkGray)
    					//, new PropertyChangedCallback(OnForegroundChanged)
    					));
    
    		public Brush Foreground
    		{
    			get { return (Brush) GetValue(ForegroundProperty); }
    			set { SetValue(ForegroundProperty, value); }
    		}
    
    		public static readonly DependencyProperty MarginProperty = DependencyProperty
    			.Register("Margin", typeof (Thickness), typeof (HintBehavior)
    				, new FrameworkPropertyMetadata(new Thickness(4, 5, 0, 0)
    					//, new PropertyChangedCallback(OnMarginChanged)
    					));
    
    		public Thickness Margin
    		{
    			get { return (Thickness) GetValue(MarginProperty); }
    			set { SetValue(MarginProperty, value); }
    		}
    
    
    		private static ResourceDictionary _hintBehaviorResources;
    
    		public static ResourceDictionary HintBehaviorResources
    		{
    			get
    			{
    				if (_hintBehaviorResources == null)
    				{
    					var res = new ResourceDictionary
    					{
    						Source = new Uri("/Mayflower.Client.Core;component/Behaviors/HintBehaviorResources.xaml",
    							UriKind.RelativeOrAbsolute)
    					};
    					_hintBehaviorResources = res;
    				}
    				return _hintBehaviorResources;
    			}
    		}
    
    
    		protected override void OnAttached()
    		{
    			base.OnAttached();
    			var t = (ControlTemplate) HintBehaviorResources["HintBehaviorWrapper"];
    			AssociatedObject.Template = t;
    			AssociatedObject.Loaded += OnLoaded;
    		}
    
    		private void OnLoaded(object sender, RoutedEventArgs e)
    		{
    			AssociatedObject.Loaded -= OnLoaded;
    			var label = (Label) AssociatedObject.Template.FindName("PART_HintLabel", AssociatedObject);
    			label.DataContext = this;
    			//label.Content = "Hello...";
    			label.SetBinding(UIElement.VisibilityProperty, new Binding("Visibility") {Source = this, Mode = BindingMode.OneWay});
    			label.SetBinding(ContentControl.ContentProperty, new Binding("Hint") {Source = this, Mode = BindingMode.OneWay});
    			label.SetBinding(Control.ForegroundProperty, new Binding("Foreground") {Source = this, Mode = BindingMode.OneWay});
    			label.SetBinding(FrameworkElement.MarginProperty, new Binding("Margin") {Source = this, Mode = BindingMode.OneWay});
    		}
    	}
