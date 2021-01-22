    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;
    
    namespace WpfApplication1
    {
      public partial class TestBrowser : Window
      {
      	public TestBrowser()
        {
          InitializeComponent();
      		var da = new DoubleAnimation(0, 10, new Duration(TimeSpan.FromSeconds(10)))
      		         	{
      		         		AutoReverse = true,
      		         		RepeatBehavior = RepeatBehavior.Forever
      		         	};
    		lbl.BeginAnimation(MyLabel.DoublePropertyProperty, da);
        }
    
      	private void ToggleLableClick(object sender, RoutedEventArgs e)
      	{
      		lbl.Visibility = lbl.IsVisible ? Visibility.Collapsed : Visibility.Visible;
      	}
      }
    
    	public class MyLabel : Label
    	{
    		public double DoubleProperty
    		{
    			get { return (double)GetValue(DoublePropertyProperty); }
    			set { SetValue(DoublePropertyProperty, value); }
    		}
    
    		public static readonly DependencyProperty DoublePropertyProperty =
    				DependencyProperty.Register("DoubleProperty", typeof(double), typeof(MyLabel), 
    				new FrameworkPropertyMetadata(0.0,
    					FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange, OnDoublePropertyChanged));
    
    		private static void OnDoublePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    		{
    			Trace.WriteLine(e.NewValue);
    		}
    
    		protected override Size MeasureOverride(Size constraint)
    		{
    			Trace.WriteLine("Measure");
    			return base.MeasureOverride(constraint);
    		}
    
    		protected override Size ArrangeOverride(Size arrangeBounds)
    		{
    			Trace.WriteLine("Arrange");
    			return base.ArrangeOverride(arrangeBounds);
    		}
    	}
    }
