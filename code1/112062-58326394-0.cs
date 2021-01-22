    <DataGrid x:Name="dgvFieldsMapping" Grid.Row="1" ItemsSource="{Binding}">
        <DataGrid.Columns>
            ...
            <DataGridTemplateColumn Width="*" Header="Destination Field" >
                <DataGridTemplateColumn.CellTemplate >
                    <DataTemplate >
                        <ComboBox ItemsSource="{Binding Source={StaticResource CustomerDbFields}}" SelectedValue="{Binding destinationField, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" ></ComboBox>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            ...
        </DataGrid.Columns>
    </DataGrid>
So whenever a DropDown was closed after selecting a Value, the Mousewheel would scroll that Combobox's Items and modify my Selection.
I ended up modifying my XAML to look like this:
    <DataGrid x:Name="dgvFieldsMapping" Grid.Row="1" ItemsSource="{Binding}">
        <DataGrid.Resources>
            <Style x:Key="dgvComboBox_Loaded" TargetType="ComboBox">
                <EventSetter Event="Loaded" Handler="dgvCombobox_Loaded" />
            </Style>
        </DataGrid.Resources>
        <DataGrid.Columns>
            ...
            <DataGridTemplateColumn Width="*" Header="Destination Field" >
                <DataGridTemplateColumn.CellTemplate >
                    <DataTemplate >
                        <ComboBox Style="{StaticResource dgvComboBox_Loaded}" ItemsSource="{Binding Source={StaticResource CustomerDbFields}}" SelectedValue="{Binding destinationField, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" ></ComboBox>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            ...
        </DataGrid.Columns>
    </DataGrid>
And adding these lines in codebehind
        public void dgvCombobox_Loaded(Object sender, RoutedEventArgs e)
        {
            ((ComboBox)sender).DropDownClosed -= ComboBox_OnDropDownClosed;
            ((ComboBox)sender).DropDownClosed += new System.EventHandler(ComboBox_OnDropDownClosed);
        }
        void ComboBox_OnDropDownClosed(object sender, System.EventArgs e)
        {
            dgvFieldsMapping.Focus();
        }
In this way I just move the Focus away from the ComboBox to the outer DataGrid after closing its corresponding DropDown, so I don't need to add any dummy FrameWorkElement
