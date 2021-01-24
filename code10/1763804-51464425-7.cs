    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    namespace WpfApp1
    {
	class Class1
	{
		public static DataGridTemplateColumn createImageColumn(string header, Size s)
		{
			Binding b = new Binding("img");
			
			DataTemplate dt = new DataTemplate();
			dt.DataType = typeof(Class2);
			var dtFactory = new FrameworkElementFactory(typeof(StackPanel));
			dtFactory.Name = "stack";
			dtFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
			FrameworkElementFactory imageHolder = new 
            FrameworkElementFactory(typeof(Image));
			imageHolder.SetValue(Image.SourceProperty, b);
			imageHolder.SetValue(Image.WidthProperty, s.Width);
			imageHolder.SetValue(Image.HeightProperty, s.Height);
			imageHolder.SetValue(Image.HorizontalAlignmentProperty, 
            HorizontalAlignment.Center);
			imageHolder.SetValue(Image.VerticalAlignmentProperty, 
            VerticalAlignment.Center);
			dtFactory.AppendChild(imageHolder);
			var  imageColumn = new DataGridTemplateColumn();
			imageColumn.Header = header;
			imageColumn.CellTemplate = dt;
			return imageColumn;
		}
	}
    }
