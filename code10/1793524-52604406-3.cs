    <DataGrid Name="dtgTest"  IsReadOnly="True"  VirtualizingStackPanel.VirtualizationMode="Standard"  EnableColumnVirtualization = "True" EnableRowVirtualization ="True"  MaxWidth="4000" MaxHeight="2000" Background="White" Margin="5,5,5,0" AutoGenerateColumns="False" RowHeaderWidth="0"  HorizontalGridLinesBrush="#0091EA" VerticalGridLinesBrush="#0091EA" CanUserAddRows="False" RowHeight="30" Grid.ColumnSpan="2" Grid.Row="2">
        <DataGrid.Resources>
            <Style TargetType="DataGridCell">
            <!-- If you have to apply another style, then use BasedOn-->
            <!--<Style TargetType="DataGridCell" BasedOn="{StaticResource DataGridCentering}">-->
                <EventSetter Event="PreviewMouseLeftButtonDown" Handler="PreviewMouseDown"/>
            </Style>
        </DataGrid.Resources>
        ...
    </DataGrid>
    private void PreviewMouseDown(object sender, MouseButtonEventArgs e)
    {
    	var cell = sender as DataGridCell; if (cell == null) { return; }
    	DataGridRow parGridRow = null;
    	var visParent = VisualTreeHelper.GetParent(cell);
    	while (parGridRow == null && visParent != null)
    	{
    		parGridRow = visParent as DataGridRow;
    		visParent = VisualTreeHelper.GetParent(visParent);
    	}
    	if (parGridRow == null) { return; }
    	var selectedItem = (parGridRow.DataContext as BillItemInSerie);
    	var obj = serialNumbersIn.FirstOrDefault(sn => selectedItem.DocumentItemInSeriesId == sn.DocumentItemInSeriesId);
    	obj.IsChecked= (bool)!obj.IsChecked;
    
    	//e.Handled = true;
    }
