    <Style TargetType="{x:Type local:DynamicPolyline}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type local:DynamicPolyline}">
                        <Canvas x:Name="PART_Canvas">
                            
                            <Polyline x:Name="PART_Polyline"
                                      Stroke="Black"
                                      StrokeThickness="2"
                                      />
    
                            <ItemsControl x:Name="PART_ThumbPointItemsControl"
                                          ItemsSource="{Binding Path=InputPoints, RelativeSource={RelativeSource TemplatedParent}}"
                            >
                                <ItemsControl.ItemTemplate>
                                    <DataTemplate>
                                        <Canvas>
                                            <tc:ThumbPoint X="{Binding Path=X, Mode=TwoWay}" Y="{Binding Path=Y, Mode=TwoWay}"/>
                                        </Canvas>
                                    </DataTemplate>
                                </ItemsControl.ItemTemplate>
                            </ItemsControl>
                                
                        </Canvas>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
