	private const double _sizeChangeAmount = 150;
		
		private void IncreaseContentSize_Click(object sender, RoutedEventArgs e)
		{
			SizeChangeLabel.MinWidth = SizeChangeLabel.ActualWidth + _sizeChangeAmount;
			SizeChangeLabel.MinHeight = SizeChangeLabel.ActualHeight + _sizeChangeAmount;	
		}
		private void ReduceContentSize_Click(object sender, RoutedEventArgs e)
		{
			if (SizeChangeLabel.MinWidth > 150)
				SizeChangeLabel.MinWidth = SizeChangeLabel.ActualWidth - _sizeChangeAmount;
			if (SizeChangeLabel.MinHeight > 150)
				SizeChangeLabel.MinHeight = SizeChangeLabel.ActualHeight - _sizeChangeAmount;
		}
