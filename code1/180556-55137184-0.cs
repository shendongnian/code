         public class DataGridTextBoxColumn : DataGridBoundColumn
     {
      public DataGridTextBoxColumn():base()
      {
      }
    
      protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
      {
       throw new NotImplementedException("Should not be used.");
      }
    
      protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
      {
       var control = new TextBox();
       control.Style = (Style)Application.Current.TryFindResource("textBoxStyle");
       control.FontSize = 14;
       control.VerticalContentAlignment = VerticalAlignment.Center;
       BindingOperations.SetBinding(control, TextBox.TextProperty, Binding);
        control.IsReadOnly = IsReadOnly;
       return control;
      }
     }
            <DataGrid Grid.Row="1" x:Name="exportData" Margin="15" VerticalAlignment="Stretch" ItemsSource="{Binding CSVExportData}" Style="{StaticResource dataGridStyle}">
            <DataGrid.Columns >
                <local:DataGridTextBoxColumn Header="Sample ID" Binding="{Binding SampleID}" IsReadOnly="True"></local:DataGridTextBoxColumn>
                <local:DataGridTextBoxColumn Header="Analysis Date" Binding="{Binding Date}" IsReadOnly="True"></local:DataGridTextBoxColumn>
                <local:DataGridTextBoxColumn Header="Test" Binding="{Binding Test}" IsReadOnly="True"></local:DataGridTextBoxColumn>
                <local:DataGridTextBoxColumn Header="Comment" Binding="{Binding Comment}"></local:DataGridTextBoxColumn>
            </DataGrid.Columns>
        </DataGrid>
