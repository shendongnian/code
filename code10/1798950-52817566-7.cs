    <DataGrid x:Name="GlobalShortcutsDataGrid"
        ItemsSource="{Binding GlobalShortcutsObservableCollection}"
        SelectedItem="{Binding SelectedRow}"
        AutoGenerateColumns="False">
                <i:Interaction.Behaviors>
                    <local:DataGridChangedBehavior IsDataGridChanged="{Binding Path=IsEnabled, ElementName=buttonSave}"/>
                </i:Interaction.Behaviors>
                <DataGrid.Columns >
            <DataGridTextColumn Header="Shortcut Name" Binding="{Binding ShortcutName}"></DataGridTextColumn>
            <DataGridTextColumn Header="Shortcut Path" Binding="{Binding FilePath}"></DataGridTextColumn>
        </DataGrid.Columns>
    </DataGrid>
    
    <Button x:Name="buttonSave" IsEnabled="False"
        Command="{Binding SaveCommand}"
        Content="Save Edits">
    </Button>
 
    public class DataGridChangedBehavior: Behavior<DataGrid>
    {
    	public bool IsDataGridChanged
    	{
    		get { return (bool)GetValue(IsDataGridChangedProperty); }
    		set { SetValue(IsDataGridChangedProperty, value); }
    	}
    
    	public static readonly DependencyProperty IsDataGridChangedProperty =
    		DependencyProperty.Register("IsDataGridChanged", typeof(bool), typeof(DataGridChangedBehavior), new PropertyMetadata(0));
    
    	protected override void OnAttached()
    	{
    		base.OnAttached();
    		AssociatedObject.CellEditEnding += dataGrid_CellEditEnding;
    	}
    
    	protected override void OnDetaching()
    	{
    		AssociatedObject.CellEditEnding -= dataGrid_CellEditEnding;
    		base.OnDetaching();
    	}
    
    	private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    	{
    		var tb = e.EditingElement as TextBox;
    		var bindingIsDirty = tb.GetBindingExpression(TextBox.TextProperty).IsDirty;
    		IsDataGridChanged |= (bindingIsDirty && e.EditAction == DataGridEditAction.Commit);
    	}
    }
