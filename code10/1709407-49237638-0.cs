                <DataGrid.Columns>
                    <DataGridTextColumn Binding="{Binding Comment}" Header="Comment" Width="4*" IsReadOnly="True" />
                    <DataGridTextColumn Binding="{Binding Name}" Header="Element Name" Width="*" IsReadOnly="True"/>
                    <DataGridComboBoxColumn DisplayMemberPath="Text" SelectedValuePath="ID"  Header="Value" Width="*" >
                        <DataGridComboBoxColumn.ElementStyle>
                            <Style TargetType="{x:Type ComboBox}">
                                <Setter Property="ItemsSource" Value="{Binding ComboItems}"/>
                            </Style>
                        </DataGridComboBoxColumn.ElementStyle>
                        <DataGridComboBoxColumn.EditingElementStyle>
                            <Style TargetType="{x:Type ComboBox}">
                                <Setter Property="ItemsSource" Value="{Binding ComboItems}"/>
                            </Style>
                        </DataGridComboBoxColumn.EditingElementStyle>
                    </DataGridComboBoxColumn>
