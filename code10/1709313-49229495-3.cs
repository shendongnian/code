    <DataGrid Name="dgMainGrid" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Id" Binding="{Binding Id, UpdateSourceTrigger=PropertyChanged}"/>
                <DataGridTextColumn Header="Description" Binding="{Binding Description, UpdateSourceTrigger=PropertyChanged}" />
                <DataGridComboBoxColumn Header="Student List" DisplayMemberPath="Name" SelectedValuePath="Id">
                    <DataGridComboBoxColumn.ElementStyle>
                        <Style TargetType="{x:Type ComboBox}">
                            <Setter Property="ItemsSource" Value="{Binding StudentsList}" />
                        </Style>
                    </DataGridComboBoxColumn.ElementStyle>
                    <DataGridComboBoxColumn.EditingElementStyle>
                        <Style TargetType="{x:Type ComboBox}">
                            <Setter Property="ItemsSource" Value="{Binding StudentsList}" />
                        </Style>
                    </DataGridComboBoxColumn.EditingElementStyle>
                </DataGridComboBoxColumn>
            </DataGrid.Columns>
        </DataGrid>
