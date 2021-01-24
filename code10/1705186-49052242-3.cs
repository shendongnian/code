    <ItemsControl ItemsSource="{Binding CanvasObjects}">
        <ItemsControl.Resources>
            <ScaleTransform x:Key="lineTransform"
                ScaleX="{Binding ActualWidth,
                         RelativeSource={RelativeSource AncestorType=ItemsControl}}"
                ScaleY="{Binding ActualHeight,
                         RelativeSource={RelativeSource AncestorType=ItemsControl}}"/>
        </ItemsControl.Resources>
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Canvas/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <ItemsControl ItemsSource="{Binding CanvasLines}">
                    <ItemsControl.ItemsPanel>
                        <ItemsPanelTemplate>
                            <Canvas/>
                        </ItemsPanelTemplate>
                    </ItemsControl.ItemsPanel>
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <Path Stroke="{Binding Stroke}"
                                  StrokeDashArray="{Binding StrokeDashArray}"
                                  StrokeThickness="{Binding StrokeThickness}">
                                <Path.Data>
                                    <LineGeometry
                                        Transform="{StaticResource lineTransform}"
                                        StartPoint="{Binding P1}"
                                        EndPoint="{Binding P2}"/>
                                </Path.Data>
                            </Path>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
