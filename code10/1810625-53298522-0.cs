    <DataGridComboBoxColumn Header="Person" DisplayMemberPath="Name" SelectedItemBinding="{Binding Person}">
        <DataGridComboBoxColumn.ElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding DataContext.Persons, RelativeSource={RelativeSource AncestorType=DataGrid}}" />
            </Style>
        </DataGridComboBoxColumn.ElementStyle>
        <DataGridComboBoxColumn.EditingElementStyle>
            <Style TargetType="ComboBox">
                <Setter Property="ItemsSource" Value="{Binding DataContext.Persons, RelativeSource={RelativeSource AncestorType=DataGrid}}" />
            </Style>
        </DataGridComboBoxColumn.EditingElementStyle>
    </DataGridComboBoxColumn>
