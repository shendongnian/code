    <Style x:Key="ListBoxItemStyle1" TargetType="{x:Type ListBoxItem}">
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
                <ControlTemplate TargetType="{x:Type ListBoxItem}">
                    <Border x:Name="Bd" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Padding="{TemplateBinding Padding}" SnapsToDevicePixels="true">
                        <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                    </Border>
                    <ControlTemplate.Triggers>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsMouseOver" Value="True"/>
                            </MultiTrigger.Conditions>
                            <Setter Property="Background" TargetName="Bd" Value="{StaticResource Item.MouseOver.Background}"/>
                            <!-- change this one to white? -->
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
                            <!-- change this one to white? -->
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
