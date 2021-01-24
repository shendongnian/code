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
