    <ControlTemplate TargetType="{x:Type DataGridRow}">
        <Border BorderBrush="{TemplateBinding BorderBrush}" 
                BorderThickness="{TemplateBinding BorderThickness}" 
                Background="{TemplateBinding Background}" SnapsToDevicePixels="True">
            <SelectiveScrollingGrid>
                <SelectiveScrollingGrid.ColumnDefinitions>
                    <ColumnDefinition Width="Auto"/>
                    <ColumnDefinition Width="*"/>
                </SelectiveScrollingGrid.ColumnDefinitions>
                <SelectiveScrollingGrid.RowDefinitions>
                    <RowDefinition Height="*"/>
                    <RowDefinition Height="Auto"/>
                </SelectiveScrollingGrid.RowDefinitions>
                <DataGridCellsPresenter Grid.Column="1" ItemsPanel="{TemplateBinding ItemsPanel}" 
                                        SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}">
                    <DataGridCellsPresenter.Template>
                        <ControlTemplate TargetType="DataGridCellsPresenter">
                            <DataGridCell Height="20">
                                <TextBlock HorizontalAlignment="Center" Text="{Binding IsSelected, RelativeSource={RelativeSource AncestorType=DataGridCell}}" />
                                <DataGridCell.Style>
                                    <Style TargetType="DataGridCell">
                                        <EventSetter Event="PreviewMouseLeftButtonDown" Handler="DataGridCell_MouseLeftButtonDown" />
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding IsSelected, RelativeSource={RelativeSource AncestorType=DataGridRow}}" Value="True">
                                                <Setter Property="Background" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}"/>
                                                <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.HighlightTextBrushKey}}"/>
                                                <Setter Property="BorderBrush" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}"/>
                                            </DataTrigger>
                                            <Trigger Property="IsKeyboardFocusWithin" Value="True">
                                                <Setter Property="BorderBrush" Value="{DynamicResource {x:Static DataGrid.FocusBorderBrushKey}}"/>
                                            </Trigger>
                                            <Trigger Property="IsEnabled" Value="false">
                                                <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
                                            </Trigger>
                                        </Style.Triggers>
                                    </Style>
                                </DataGridCell.Style>
                            </DataGridCell>
                        </ControlTemplate>
                    </DataGridCellsPresenter.Template>
                </DataGridCellsPresenter>
                <DataGridRowHeader Grid.RowSpan="2" SelectiveScrollingGrid.SelectiveScrollingOrientation="Vertical" Visibility="{Binding HeadersVisibility, ConverterParameter={x:Static DataGridHeadersVisibility.Row}, Converter={x:Static DataGrid.HeadersVisibilityConverter}, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}"/>
            </SelectiveScrollingGrid>
        </Border>
    </ControlTemplate>
----------
    private void DataGridCell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DataGridCell cell = (DataGridCell)sender;
        DataGrid dataGrid = FindParent<DataGrid>(cell);
        dataGrid.SelectedItem = cell.DataContext;
    }
    private static T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
    {
        var parent = VisualTreeHelper.GetParent(dependencyObject);
        if (parent == null) return null;
        var parentT = parent as T;
        return parentT ?? FindParent<T>(parent);
    }
