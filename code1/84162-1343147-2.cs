    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication1
    {
    	public partial class Window1 : Window
    	{
    		public Window1()
    		{
    			InitializeComponent();
    		}
    
    		private void DragCompleteHandler(object sender, RoutedEventArgs e)
    		{
    			MessageBox.Show("YEP");
    		}
    	}
    
    	public class CustomControl : TextBox
    	{
    	}
    
    	public class DragHelper : DependencyObject
    	{
    		public static readonly DependencyProperty IsDragSourceProperty = DependencyProperty.RegisterAttached("IsDragSource",
    			typeof(bool),
    			typeof(DragHelper),
    			new FrameworkPropertyMetadata(OnIsDragSourceChanged));
    
    		public static bool GetIsDragSource(DependencyObject depO)
    		{
    			return (bool)depO.GetValue(IsDragSourceProperty);
    		}
    
    		public static void SetIsDragSource(DependencyObject depO, bool ids)
    		{
    			depO.SetValue(IsDragSourceProperty, ids);
    		}
    
    		public static readonly RoutedEvent DragCompleteEvent = EventManager.RegisterRoutedEvent(
    			"DragComplete",
    			RoutingStrategy.Bubble,
    			typeof(RoutedEventHandler),
    			typeof(DragHelper)
    		);
    
    		public static void AddDragCompleteHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
    		{
    			UIElement element = dependencyObject as UIElement;
    			if (element != null)
    			{
    				element.AddHandler(DragCompleteEvent, handler);
    			}
    		}
    
    		public static void RemoveDragCompleteHandler(DependencyObject dependencyObject, RoutedEventHandler handler)
    		{
    			UIElement element = dependencyObject as UIElement;
    			if (element != null)
    			{
    				element.RemoveHandler(DragCompleteEvent, handler);
    			}
    		}
    
    		private static void OnIsDragSourceChanged(DependencyObject depO, DependencyPropertyChangedEventArgs e)
    		{
    			(depO as TextBox).TextChanged += delegate
    			{
    				(depO as TextBox).RaiseEvent(new RoutedEventArgs(DragCompleteEvent, null));
    			};
    		}
    	}
    }
