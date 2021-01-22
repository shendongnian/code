    public class MyImage : System.Windows.Controls.Image
    {
        public double Weight
        {
            get { return (double)GetValue(WeightProperty); }
            set { SetValue(WeightProperty, value); }
        }
    
        // Using a DependencyProperty as the backing store for Weight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WeightProperty =
            DependencyProperty.Register("Weight", typeof(double), typeof(MyImage), new UIPropertyMetadata(0.0));
    
    }
