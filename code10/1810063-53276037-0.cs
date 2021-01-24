    <DataGrid AutoGenerateColumns="False" x:Name="DataGrid1" HorizontalAlignment="Left" Height="135" Margin="21,288,0,0" VerticalAlignment="Top" Width="729" DataContext="{Binding ElementName=Window1}" ItemsSource="{Binding ProductSet}" >
        <DataGrid.Columns>
            <DataGridTextColumn Header="ProductID" Width="175" Binding="{Binding ProductID}"></DataGridTextColumn>
                <DataGridComboBoxColumn   Header="Category"    DisplayMemberPath="Name" SelectedValuePath="CategoryID" SelectedItemBinding="{Binding ListOfCategory}">
                    <DataGridComboBoxColumn.ElementStyle>
                        <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{Binding Path=DataContext.ListOfCategory, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type DataGrid}}}" />
                        </Style>
                    </DataGridComboBoxColumn.ElementStyle>
                    <DataGridComboBoxColumn.EditingElementStyle>
                            <Style TargetType="ComboBox">
                            <Setter Property="ItemsSource" Value="{Binding Path=DataContext.ListOfCategory,RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type DataGrid}}}" />
                        </Style>
                        </DataGridComboBoxColumn.EditingElementStyle>
        </DataGridComboBoxColumn>
            <DataGridTextColumn Header="Name" Width="175" Binding="{Binding Name}"></DataGridTextColumn>
            <DataGridTextColumn Header="Price " Width="175" Binding="{Binding Price }"></DataGridTextColumn>
        </DataGrid.Columns>
    </DataGrid>
