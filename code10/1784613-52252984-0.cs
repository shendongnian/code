    <Style TargetType="{x:Type DataGridRow}">       
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type DataGridRow}">
                        <Grid x:Name="selectedRow">                        
                                <DataGridCellsPresenter
                                    ItemsPanel="{TemplateBinding ItemsControl.ItemsPanel}"
                                    SnapsToDevicePixels="{TemplateBinding UIElement.SnapsToDevicePixels}"
                                    Grid.Column="1" />
                                <DataGridDetailsPresenter
                                    Visibility="{TemplateBinding DataGridRow.DetailsVisibility}"
                                    Grid.Column="1"
                                    Grid.Row="1"
                                    SelectiveScrollingGrid.SelectiveScrollingOrientation="Both" />
                                <DataGridRowHeader
                                    Visibility="Visible"
                                    Grid.RowSpan="2"
                                    SelectiveScrollingGrid.SelectiveScrollingOrientation="Vertical" />
                            </SelectiveScrollingGrid>
                        </Grid>
                        <ControlTemplate.Triggers>                                                        
                            <Trigger Property="IsSelected" Value="True">
                                <Setter Property="Background" Value="{DynamicResource ApplicationAccentBrushSecondary}" TargetName="selectedRow" />
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
