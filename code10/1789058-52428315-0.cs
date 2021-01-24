    <DataGrid ... AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Header="Control Type" Binding="{Binding ControlType}" />
            <DataGridTemplateColumn Header="Dynamic Control">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <ContentControl>
                            <ContentControl.Style>
                                <Style TargetType="ContentControl">
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding ControlType}" Value="ComboBox">
                                            <Setter Property="Content">
                                                <Setter.Value>
                                                    <ComboBox />
                                                </Setter.Value>
                                            </Setter>
                                        </DataTrigger>
                                        <DataTrigger Binding="{Binding ControlType}" Value="TextBox">
                                            <Setter Property="Content">
                                                <Setter.Value>
                                                    <TextBox Text="text...." />
                                                </Setter.Value>
                                            </Setter>
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </ContentControl.Style>
                        </ContentControl>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
