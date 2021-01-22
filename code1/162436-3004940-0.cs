	public class CustomPanel : Panel
	{
		/// <summary>
		/// RequiredHeight Attached Dependency Property
		/// </summary>
		public static readonly DependencyProperty RequiredHeightProperty = DependencyProperty.RegisterAttached("RequiredHeight", typeof(double), typeof(CustomPanel), new FrameworkPropertyMetadata((double)double.NaN, FrameworkPropertyMetadataOptions.AffectsMeasure, new PropertyChangedCallback(OnRequiredHeightPropertyChanged)));
		private static void OnRequiredHeightPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
		{ 
			
		}
		public static double GetRequiredHeight(DependencyObject d)
		{
			return (double)d.GetValue(RequiredHeightProperty);
		}
		public static void SetRequiredHeight(DependencyObject d, double value)
		{
			d.SetValue(RequiredHeightProperty, value);
		}
		private double m_ExtraSpace = 0;
		private double m_NormalSpace = 0;
		protected override Size MeasureOverride(Size availableSize)
		{
			//Measure the children...
			foreach (UIElement child in Children)
				child.Measure(availableSize);
			//Sort them depending on their desired size...
			var sortedChildren = Children.Cast<UIElement>().OrderBy<UIElement, double>(new Func<UIElement, double>(delegate(UIElement child)
			{
				return GetRequiredHeight(child);
			}));
			//Compute remaining space...
			double remainingSpace = availableSize.Height;
			m_NormalSpace = 0.0;
			int remainingChildren = Children.Count;
			foreach (UIElement child in sortedChildren)
			{
				m_NormalSpace = remainingSpace / remainingChildren;
				double height = GetRequiredHeight(child);
				if (height < m_NormalSpace) // if == there would be no point continuing as there would be no remaining space
					remainingSpace -= height;
				else
				{
					remainingSpace = 0;
					break;
				}
				remainingChildren--;
			}
			//Dtermine the extra space to add to every child...
			m_ExtraSpace = remainingSpace / Children.Count;
			return Size.Empty;  //The panel should take all the available space...
		}
		protected override System.Windows.Size ArrangeOverride(System.Windows.Size finalSize)
		{
			double offset = 0.0;
			foreach (UIElement child in Children)
			{
				double height = GetRequiredHeight(child);
				double value = (double.IsNaN(height) ? m_NormalSpace : Math.Min(height, m_NormalSpace)) + m_ExtraSpace;
				child.Arrange(new Rect(0, offset, finalSize.Width, value));
				offset += value;
			}
			return finalSize;   //The final size is the available size...
		}
	}
