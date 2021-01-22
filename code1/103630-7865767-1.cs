    <HierarchicalDataTemplate DataType="{x:Type SomeViewModelType}" ItemsSource="{Binding Path=Children}">
        <StackPanel Orientation="Horizontal">
            <StackPanel.Resources>
                <SolidColorBrush x:Key="{x:Static SystemColors.HighlightBrushKey}" Color="{Binding Source={StaticResource {x:Static SystemColors.HighlightBrushKey}}, Path=Color}" />
                <SolidColorBrush x:Key="{x:Static SystemColors.ControlBrushKey}" Color="{Binding Source={StaticResource {x:Static SystemColors.ControlBrushKey}}, Path=Color}" />
            </StackPanel.Resources>
            <Image SnapsToDevicePixels="True" Source="...">
            </Image>
            <TextBlock Text="{Binding Path=DisplayName}" Margin="5,0">
                <TextBlock.Resources>
                    <Style TargetType="{x:Type TextBlock}">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type TreeViewItem}}, Path=IsSelected}" Value="True">
                                <Setter Property="Background" Value="{DynamicResource _CustomHighlightBrushKey}" />
                            </DataTrigger>
                            <MultiDataTrigger>
                                <MultiDataTrigger.Conditions>
                                    <Condition Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type TreeViewItem}}, Path=IsSelected}" Value="True" />
                                    <Condition Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type TreeViewItem}}, Path=IsSelectionActive}" Value="False" />
                                </MultiDataTrigger.Conditions>
                                <Setter Property="Background" Value="{DynamicResource _CustomControlBrushKey}" />
                            </MultiDataTrigger>
                        </Style.Triggers>
                    </Style>
                </TextBlock.Resources>
            </TextBlock>
        </StackPanel>
    </HierarchicalDataTemplate>
