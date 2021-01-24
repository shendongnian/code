    <DataGridTemplateColumn>
        <DataGridTemplateColumn.Header>
            <Grid Background="Gray" Width="25" Height="25"
                  Tag="{Binding Columns, ElementName=MyGrid}">
                <Grid.ContextMenu>
                    <ContextMenu ItemsSource="{Binding PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                        <ContextMenu.ItemTemplate>
                            <DataTemplate>
                                <CheckBox x:Name="chk">
                                    <CheckBox.IsChecked>
                                        <Binding Path="Visibility">
                                            <Binding.Converter>
                                                <local:VisibilityToBooleanConverter />
                                            </Binding.Converter>
                                        </Binding>
                                    </CheckBox.IsChecked>
                                    <CheckBox.Content>
                                        <TextBlock Text="{Binding Header}" />
                                    </CheckBox.Content>
                                </CheckBox>
                                <DataTemplate.Triggers>
                                    <!-- hide the last column in the ContentMenu-->
                                    <DataTrigger Binding="{Binding DisplayIndex}" Value="5">
                                        <Setter TargetName="chk" Property="Visibility" Value="Collapsed" />
                                    </DataTrigger>
                                </DataTemplate.Triggers>
                            </DataTemplate>
                        </ContextMenu.ItemTemplate>
                    </ContextMenu>
                </Grid.ContextMenu>
            </Grid>
        </DataGridTemplateColumn.Header>
    </DataGridTemplateColumn>
