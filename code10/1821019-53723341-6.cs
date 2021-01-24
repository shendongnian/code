    <Style x:Key="TooltipPopupFadeAway" TargetType="ToolTip">
        <Setter Property="Background" Value="Transparent"/>
        <Setter Property="BorderThickness" Value="0"/>
        <Setter Property="Opacity" Value="0"/>
        <Setter Property="IsOpen" Value="False"/>
        <Style.Triggers>
            <Trigger Property="IsOpen" Value="True">
                <Trigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetProperty="Opacity"
                                             Duration="0:0:1" From="3" To="0"/>
                        </Storyboard>
                    </BeginStoryboard>
                </Trigger.EnterActions>
            </Trigger>
        </Style.Triggers>
    </Style>
