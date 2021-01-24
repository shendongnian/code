    <Style x:Key="TooltipPopupFadeAway" TargetType="ToolTip">
        <Setter Property="Background" Value="Transparent"/>
        <Setter Property="BorderThickness" Value="0"/>
        <Setter Property="IsOpen" Value="False"/>
        <Style.Triggers>
            <Trigger Property="IsOpen" Value="True">
                <Trigger.EnterActions>
                    <BeginStoryboard>
                        <Storyboard>
                            <DoubleAnimation Storyboard.TargetProperty="Opacity"
                                             BeginTime="0:0:0.67" Duration="0:0:0.33"
                                             To="0" FillBehavior="Stop" />
                            <ObjectAnimationUsingKeyFrames
                                Storyboard.TargetProperty="Visibility">
                                <DiscreteObjectKeyFrame
                                    KeyTime="0:0:0"
                                    Value="{x:Static Visibility.Visible}"/>
                                <DiscreteObjectKeyFrame
                                    KeyTime="0:0:1"
                                    Value="{x:Static Visibility.Hidden}"/>
                            </ObjectAnimationUsingKeyFrames>
                        </Storyboard>
                    </BeginStoryboard>
                </Trigger.EnterActions>
            </Trigger>
        </Style.Triggers>
    </Style>
