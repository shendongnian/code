    <Style TargetType="TreeView" 
           xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
           xmlns:s="clr-namespace:System;assembly=mscorlib" 
           xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
        <Style.Triggers>
            <Trigger Property="VirtualizingStackPanel.IsVirtualizing">
                <Setter Property="ItemsControl.ItemsPanel">
                    <Setter.Value>
                        <ItemsPanelTemplate><VirtualizingStackPanel IsItemsHost="True" /></ItemsPanelTemplate>
                    </Setter.Value>
                </Setter>
                <Trigger.Value>
                    <s:Boolean>True</s:Boolean>
                </Trigger.Value>
            </Trigger>
        </Style.Triggers>
        <Style.Resources>
            <ResourceDictionary />
        </Style.Resources>
        <Setter Property="Panel.Background">
            <Setter.Value><DynamicResource ResourceKey="{x:Static SystemColors.WindowBrushKey}" /></Setter.Value>
        </Setter>
        <Setter Property="Border.BorderBrush">
            <Setter.Value><SolidColorBrush>#FF828790</SolidColorBrush></Setter.Value>
        </Setter>
        <Setter Property="Border.BorderThickness">
            <Setter.Value><Thickness>1,1,1,1</Thickness></Setter.Value>
        </Setter>
        <Setter Property="Control.Padding">
            <Setter.Value><Thickness>1,1,1,1</Thickness></Setter.Value>
        </Setter>
        <Setter Property="TextElement.Foreground">
            <Setter.Value><DynamicResource ResourceKey="{x:Static SystemColors.ControlTextBrushKey}" /></Setter.Value>
        </Setter>
        <Setter Property="ScrollViewer.HorizontalScrollBarVisibility">
            <Setter.Value><x:Static Member="ScrollBarVisibility.Auto" /></Setter.Value>
        </Setter>
        <Setter Property="ScrollViewer.VerticalScrollBarVisibility">
            <Setter.Value><x:Static Member="ScrollBarVisibility.Auto" /></Setter.Value>
        </Setter>
        <Setter Property="Control.VerticalContentAlignment">
            <Setter.Value><x:Static Member="VerticalAlignment.Center" /></Setter.Value>
        </Setter>
        <Setter Property="Control.Template">
            <Setter.Value>
                <ControlTemplate TargetType="TreeView">
                    <Border BorderThickness="{TemplateBinding Border.BorderThickness}" 
                            BorderBrush="{TemplateBinding Border.BorderBrush}" 
                            Name="Bd" SnapsToDevicePixels="True">
                        <ScrollViewer CanContentScroll="False" 
                                      HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}" 
                                      VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}" 
                                      Background="{TemplateBinding Panel.Background}" 
                                      Padding="{TemplateBinding Control.Padding}" 
                                      Name="_tv_scrollviewer_" 
                                      SnapsToDevicePixels="{TemplateBinding UIElement.SnapsToDevicePixels}" 
                                      Focusable="False">
                            <ItemsPresenter />
                        </ScrollViewer>
                    </Border>
                    <ControlTemplate.Triggers>
                        <Trigger Property="UIElement.IsEnabled">
                            <Setter Property="Panel.Background" TargetName="Bd">
                                <Setter.Value>
                                    <DynamicResource ResourceKey="{x:Static SystemColors.ControlBrushKey}" />
                                </Setter.Value>
                            </Setter>
                            <Trigger.Value>
                                <s:Boolean>False</s:Boolean>
                            </Trigger.Value>
                        </Trigger>
                        <Trigger Property="VirtualizingStackPanel.IsVirtualizing">
                            <Setter Property="ScrollViewer.CanContentScroll" TargetName="_tv_scrollviewer_">
                                <Setter.Value><s:Boolean>True</s:Boolean></Setter.Value>
                            </Setter>
                            <Trigger.Value>
                                <s:Boolean>True</s:Boolean>
                            </Trigger.Value>
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
