    <Setter Property="Template">
        <Setter.Value>
            <ControlTemplate TargetType="{x:Type ListBoxItem}">
                <Border x:Name="Bd"
                        Background="{TemplateBinding Background}"
                        BorderBrush="{TemplateBinding BorderBrush}"
                        BorderThickness="{TemplateBinding BorderThickness}"
                        Padding="{TemplateBinding Padding}"
                        SnapsToDevicePixels="True">
                    <ContentPresenter HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                        VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                        Content="{TemplateBinding Content}"
                                        ContentStringFormat="{TemplateBinding ContentStringFormat}"
                                        ContentTemplate="{TemplateBinding ContentTemplate}"
                                        SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" />
                </Border>
                <ControlTemplate.Triggers>
                    <MultiTrigger>
                        <MultiTrigger.Conditions>
                            <Condition Property="IsMouseOver" Value="True" />
                        </MultiTrigger.Conditions>
                        <Setter TargetName="Bd" Property="Background" Value="Transparent" />
                        <Setter TargetName="Bd" Property="BorderBrush" Value="Transparent" />
                    </MultiTrigger>
                    <MultiTrigger>
                        <MultiTrigger.Conditions>
                            <Condition Property="Selector.IsSelectionActive" Value="False" />
                            <Condition Property="IsSelected" Value="True" />
                        </MultiTrigger.Conditions>
                        <Setter TargetName="Bd" Property="Background" Value="Transparent" />
                        <Setter TargetName="Bd" Property="BorderBrush" Value="Transparent" />
                    </MultiTrigger>
                    <MultiTrigger>
                        <MultiTrigger.Conditions>
                            <Condition Property="Selector.IsSelectionActive" Value="True" />
                            <Condition Property="IsSelected" Value="True" />
                        </MultiTrigger.Conditions>
                        <Setter TargetName="Bd" Property="Background" Value="Transparent" />
                        <Setter TargetName="Bd" Property="BorderBrush" Value="Transparent" />
                    </MultiTrigger>
                    <Trigger Property="IsEnabled" Value="False">
                        <Setter TargetName="Bd" Property="TextElement.Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}" />
                    </Trigger>
                </ControlTemplate.Triggers>
            </ControlTemplate>
        </Setter.Value>
    </Setter>
