    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    
    public class RatioConverter : IValueConverter
    {
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		// Input santize first..
    		return (System.Convert.ToDouble(value)) * this.Ratio;
    	}
    	
    	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    	{
    		throw new NotImplementedException();
    	}
    	
    	public Double Ratio
    	{
    		get { return (Double)GetValue(RatioProperty); }
    		set { SetValue(RatioProperty, value); }
    	}
    	
    	public static readonly DependencyProperty RatioProperty = DependencyProperty.Register(
    		"Ratio", typeof(Double), typeof(RatioConverter), new FrameworkPropertyMetadata(1.0));
    }
