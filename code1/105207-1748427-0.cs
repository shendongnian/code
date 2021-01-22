    public class FrameworkElementInfo
	{
		Point _position				= new Point();
		FrameworkElement _element	= null;
		public Point Position
		{
			get { return _position; }
			set { _position = value; }
		}
		public FrameworkElement FrameworkElement
		{
			get { return _element; }
			set { _element = value; }
		}
	}
	public class ScrollViewPositionManager
	{
		ScrollViewer _scrollViewer				= null;
		List<FrameworkElementInfo> _elements	= new List<FrameworkElementInfo>();
		double _zoom							= 100.0;
		public ScrollViewPositionManager(ScrollViewer scrollViewer, double zoom)
		{
			_scrollViewer = scrollViewer;
			_zoom = zoom;
		}
		public void RegisterElement(FrameworkElement element, Boolean registerOnly)
		{
			FrameworkElementInfo info = new FrameworkElementInfo();
			if (!registerOnly)	info.Position = CalculatePosition(element);
			info.FrameworkElement	= element;
			_elements.Add(info);
		}
		public void RecalculatePositions()
		{
			int Counter = 0;
			foreach(FrameworkElementInfo info in _elements)
			{
				Counter += 1;
				info.Position = CalculatePosition(info.FrameworkElement);
			}
		}
		public List<FrameworkElement> GetElementsInViewPort()
		{
			List<FrameworkElement> elements = new List<FrameworkElement>();
			double verticalOffsetHigh = _scrollViewer.ViewportHeight + _scrollViewer.VerticalOffset;
			foreach (FrameworkElementInfo info in _elements)
			{
				Point point = info.Position;
				if (point.Y >= _scrollViewer.VerticalOffset &&
					point.Y <= verticalOffsetHigh)
				{
					elements.Add(info.FrameworkElement);
				}
			}
			return elements;
		}
		private Point CalculatePosition(FrameworkElement element)
		{
			GeneralTransform elementTransform = element.TransformToAncestor(_scrollViewer);
			Point elementPoint = elementTransform.Transform(new Point(0, 0));
			Point transformedPoint = new Point(elementPoint.X, elementPoint.Y);
			transformedPoint = GetZoomedPoint(elementPoint, _zoom, _scrollViewer.HorizontalOffset, _scrollViewer.VerticalOffset);
			return transformedPoint;
		}
		static public Point GetZoomedPoint(Point unzoomedPoint, double zoom, double offsetX, double offsetY)
		{
			Point zoomedPoint = new Point();
			double zoomFactor = 100.0 / zoom;
			
			zoomedPoint.X = offsetX + unzoomedPoint.X * zoomFactor;
			zoomedPoint.Y = offsetY + unzoomedPoint.Y * zoomFactor;
			return zoomedPoint;
		}
		public int ElementCount
		{
			get { return _elements.Count; }
		}
		public FrameworkElement GetFirstElement()
		{
			FrameworkElement firstElement = null;
			if(_elements.Count > 0) firstElement = _elements[0].FrameworkElement;
			return firstElement;
		}
		public FrameworkElement GetLastElement()
		{
			FrameworkElement lastElement = null;
			if (_elements.Count > 0) lastElement = _elements[_elements.Count-1].FrameworkElement;
			return lastElement;
		}
		public FrameworkElement GetNextElement(FrameworkElement element)
		{
			FrameworkElement nextElement = null;
			int index = GetElementIndex(element);
			if(index != -1 && index != _elements.Count -1)
			{			
				nextElement = _elements[index + 1].FrameworkElement;
			}
			return nextElement;
		}
		public FrameworkElement GetPreviousElement(FrameworkElement element)
		{
			FrameworkElement previousElement = null;
			int index = GetElementIndex(element);
			if (index > 1)
			{
				previousElement = _elements[index - 1].FrameworkElement;
			}
			return previousElement;
		}
		public int GetElementIndex(FrameworkElement element)
		{
			return _elements.FindIndex(
								delegate(FrameworkElementInfo currentElement)
								{
									if(currentElement.FrameworkElement == element) return true;
									return false;
								}
			);
		}
	}
