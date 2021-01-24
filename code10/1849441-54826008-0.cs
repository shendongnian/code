    <ListView x:Name="ListViewCollections" ItemsSource="{Binding}">
        <ListView.Resources>
            <SolidColorBrush x:Key="Item.MouseOver.Background" Color="#1F26A0DA"/>
            <SolidColorBrush x:Key="Item.MouseOver.Border" Color="#a826A0Da"/>
            <SolidColorBrush x:Key="Item.SelectedInactive.Background" Color="#3DDADADA"/>
            <SolidColorBrush x:Key="Item.SelectedInactive.Border" Color="#FFDADADA"/>
            <SolidColorBrush x:Key="Item.SelectedActive.Background" Color="#3D26A0DA"/>
            <SolidColorBrush x:Key="Item.SelectedActive.Border" Color="#FF26A0DA"/>
            <Style x:Key="FocusVisual">
                <Setter Property="Control.Template">
                    <Setter.Value>
                        <ControlTemplate>
                            <Rectangle Margin="2" SnapsToDevicePixels="true" Stroke="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}" StrokeThickness="1" StrokeDashArray="1 2"/>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ListView.Resources>
        <ListView.ItemContainerStyle>
            <Style TargetType="{x:Type ListViewItem}">
                <Setter Property="SnapsToDevicePixels" Value="True"/>
                <Setter Property="Padding" Value="4,1"/>
                <Setter Property="HorizontalContentAlignment" Value="{Binding HorizontalContentAlignment, RelativeSource={RelativeSource AncestorType={x:Type ItemsControl}}}"/>
                <Setter Property="VerticalContentAlignment" Value="{Binding VerticalContentAlignment, RelativeSource={RelativeSource AncestorType={x:Type ItemsControl}}}"/>
                <Setter Property="Background" Value="Transparent"/>
                <Setter Property="BorderBrush" Value="Transparent"/>
                <Setter Property="BorderThickness" Value="1"/>
                <Setter Property="FocusVisualStyle" Value="{StaticResource FocusVisual}"/>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type ListViewItem}">
                            <Border x:Name="Bd" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Padding="{TemplateBinding Padding}" SnapsToDevicePixels="true">
                                <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                            </Border>
                            <ControlTemplate.Triggers>
                                <MultiTrigger>
                                    <MultiTrigger.Conditions>
                                        <Condition Property="IsMouseOver" Value="True"/>
                                    </MultiTrigger.Conditions>
                                    <Setter Property="Background" TargetName="Bd" Value="{StaticResource Item.MouseOver.Background}"/>
                                    <Setter Property="BorderBrush" TargetName="Bd" Value="{StaticResource Item.MouseOver.Border}"/>
                                </MultiTrigger>
                                <MultiTrigger>
                                    <MultiTrigger.Conditions>
                                        <Condition Property="Selector.IsSelectionActive" Value="False"/>
                                        <Condition Property="IsSelected" Value="True"/>
                                    </MultiTrigger.Conditions>
                                    <Setter Property="Background" TargetName="Bd" Value="{StaticResource Item.SelectedInactive.Background}"/>
                                    <Setter Property="BorderBrush" TargetName="Bd" Value="{StaticResource Item.SelectedInactive.Border}"/>
                                </MultiTrigger>
                                <MultiTrigger>
                                    <MultiTrigger.Conditions>
                                        <Condition Property="Selector.IsSelectionActive" Value="True"/>
                                        <Condition Property="IsSelected" Value="True"/>
                                    </MultiTrigger.Conditions>
                                    <Setter Property="Background" TargetName="Bd" Value="{StaticResource Item.SelectedActive.Background}"/>
                                    <Setter Property="BorderBrush" TargetName="Bd" Value="{StaticResource Item.SelectedActive.Border}"/>
                                </MultiTrigger>
                                <Trigger Property="IsEnabled" Value="False">
                                    <Setter Property="TextElement.Foreground" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.ItemTemplate>
            <DataTemplate>
                <DockPanel Style="{StaticResource DockPanelStyle}">
                    <Image Source="{Binding something}"/>
                    <StackPanel Orientation="Vertical">
                        <TextBlock Text="{Binding something}"/>
                        <TextBlock Text="{Binding something}"/>
                    </StackPanel>
                </DockPanel>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
