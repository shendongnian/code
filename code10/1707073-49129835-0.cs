        <DataGridTemplateColumn.CellStyle>
            <Style TargetType="ContentControl">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Type}" Value="comboBox">
                        <Setter Property="ContentTemplate">
                            <Setter.Value>
                                <DataTemplate>
                                    <ComboBox Height="22" Name="comboBox1">
                                        <ComboBoxItem Content="X"/>
                                        <ComboBoxItem Content="Y"/>
                                        <ComboBoxItem Content="Z"/>
                                    </ComboBox>
                                </DataTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>                                
            </Style>
        </DataGridTemplateColumn.CellStyle>
