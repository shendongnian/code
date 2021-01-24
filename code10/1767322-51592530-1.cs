         PinsData = new List<PinsDataItem>();
			for (int i = 0; i < Pins.Count; i++)
			{
				PinsData.Add(new PinsDataItem("X"));
				TextBox t = new TextBox()
				{
					Margin = new Thickness(2, 0, 2, 0),
					Padding = new Thickness(0),
					Width = 14,
					FontSize = 13,
					FontWeight = FontWeights.Medium,
					FontFamily = new FontFamily("Courier New"),
					HorizontalAlignment = HorizontalAlignment.Center,
					VerticalAlignment = VerticalAlignment.Stretch,
					HorizontalContentAlignment = HorizontalAlignment.Left,
					VerticalContentAlignment = VerticalAlignment.Center
				};
				Binding b = new Binding();
				b.Mode = BindingMode.TwoWay;
				b.Source = PinsData[i];
				b.Path = new PropertyPath("Text");
				t.SetBinding(TextBox.TextProperty, b);
				PinDataGrid.Items.Add(t);
			}
