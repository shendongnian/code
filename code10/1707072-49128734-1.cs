    <DataGrid Name="dg" Width="400" Height="300" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding Name}"/>
                <DataGridTemplateColumn Header="Value" Width="*">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel>
                                <TextBlock Name="textbox1" Text="{Binding Address}">
                                    <TextBlock.Style>
                                        <Style TargetType="{x:Type TextBlock}">
                                            <Setter Property="Visibility" Value="Hidden"/>
                                            <Style.Triggers>
                                                <DataTrigger Binding="{Binding Address}" Value="Pune">
                                                    <Setter Property="Visibility" Value="Visible"/>
                                                </DataTrigger>
                                                <DataTrigger Binding="{Binding Address}" Value="Mumbai">
                                                    <Setter Property="Visibility" Value="Hidden"/>
                                                </DataTrigger>
                                            </Style.Triggers>
                                        </Style>
                                    </TextBlock.Style>
                                </TextBlock>
                                <ComboBox Height="22" Name="comboBox1">
                                    <ComboBoxItem Content="X"/>
                                    <ComboBoxItem Content="Y"/>
                                    <ComboBoxItem Content="Z"/>
                                    <ComboBox.Style>
                                        <Style TargetType="{x:Type ComboBox}">
                                            <Setter Property="Visibility" Value="Hidden"/>
                                            <Style.Triggers>
                                                <DataTrigger Binding="{Binding Address}" Value="Mumbai">
                                                    <Setter Property="Visibility" Value="Visible"/>
                                                </DataTrigger>
                                            </Style.Triggers>
                                        </Style>
                                    </ComboBox.Style>
                                </ComboBox>
                            </StackPanel>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
            </DataGrid.Columns>
    </DataGrid>
