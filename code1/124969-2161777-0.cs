    public static double GetWeight(DependencyObject obj)
			{
				return (double)obj.GetValue(WeightProperty);
			}
			public static void SetWeight(DependencyObject obj, double value)
			{
				obj.SetValue(WeightProperty, value);
			}
			public static readonly DependencyProperty WeightProperty =
				Dependenc**strong text**yProperty.RegisterAttached("Weight", typeof(double), typeof(MainWindow));
