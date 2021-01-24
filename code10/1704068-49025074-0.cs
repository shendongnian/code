    public class MyItem : Control
     {
         public string MyData
         {
             get { return (string)GetValue(MyDataProperty); }
             set { SetValue(MyDataProperty, value); }
         }
    
         // Using a DependencyProperty as the backing store for MyData.  This enables animation, styling, binding, etc...
         public static readonly DependencyProperty MyDataProperty =
             DependencyProperty.Register("MyData", typeof(string), typeof(MyItem), new PropertyMetadata("", DPC));
    
         private static void DPC(DependencyObject d, DependencyPropertyChangedEventArgs e)
         {
             Debug.WriteLine("CHANGED!!");
         }
     }
