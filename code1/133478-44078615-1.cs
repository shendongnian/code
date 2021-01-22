    <Style TargetType="{x:Type FrameworkElement}" x:Key="ValidatingControl">
    <Style.Triggers>
        <MultiTrigger>
            <MultiTrigger.Conditions>
                <Condition Property="Validation.HasError" Value="True" />
                <Condition Property="IsVisible" Value="True" />
            </MultiTrigger.Conditions>
            <Setter Property="Validation.ErrorTemplate">
                <Setter.Value>
                    <ControlTemplate>
                        <DockPanel LastChildFill="True">
                            <Border BorderBrush="Red" BorderThickness="1">
                                <AdornedElementPlaceholder Name="controlWithError"/>
                            </Border>
                        </DockPanel>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Setter Property="ToolTip" 
            Value="{Binding RelativeSource={x:Static RelativeSource.Self}, Path=(Validation.Errors).CurrentItem.ErrorContent}" />
        </MultiTrigger>
    </Style.Triggers>
