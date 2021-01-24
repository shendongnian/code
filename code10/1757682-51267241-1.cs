                         <DataGridTemplateColumn>
                                <DataGridTemplateColumn.CellStyle>
                                    <Style TargetType="DataGridCell">
                                        <Setter Property="IsTabStop" Value="False" />
                                        <Setter Property="BorderThickness" Value="0"/>                                        
                                    </Style>
                                </DataGridTemplateColumn.CellStyle>
                                <DataGridTemplateColumn.CellTemplate>
                                    <DataTemplate>
                                        <Button behaviors:FocusExtension.IsFocused="{Binding Selected}"
                                             Command="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type controls:MetroWindow}}, Path=DataContext.AddCommand}"
                                                CommandParameter="{Binding}">
                                            <Button.InputBindings>
                                                <KeyBinding Key="Enter" Command="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type controls:MetroWindow}}, Path=DataContext.AddCommand}"
                                                CommandParameter="{Binding}"/>
                                            </Button.InputBindings>
                                            <iconPacks:PackIconFontAwesome Kind="PlusCircle" Foreground="#FF94bf00"/>
                                        </Button>
                                    </DataTemplate>
                                </DataGridTemplateColumn.CellTemplate>
                            </DataGridTemplateColumn>
