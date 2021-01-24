    <ScrollViewer Height="300" ScrollViewer.HorizontalScrollBarVisibility="Disabled">
        <ScrollViewer.Resources>
            <Style TargetType="ScrollBar">
                <Style.Resources>
                    <Style TargetType="{x:Type Track}">
                        <Style.Triggers>
                            <Trigger Property="IsVisible" Value="True">
                                <Trigger.EnterActions>
                                    <BeginStoryboard x:Name="SetValue">
                                        <Storyboard Storyboard.TargetProperty="(Track.IsDirectionReversed)">
                                            <BooleanAnimationUsingKeyFrames RepeatBehavior="Forever" Duration="24:00:00">
                                                <DiscreteBooleanKeyFrame Value="False" KeyTime="00:00:00"/>
                                            </BooleanAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </BeginStoryboard>
                                </Trigger.EnterActions>
                                <Trigger.ExitActions>
                                    <StopStoryboard BeginStoryboardName="SetValue"/>
                                </Trigger.ExitActions>
                            </Trigger>
                        </Style.Triggers>
                    </Style>
                </Style.Resources>
            </Style>
        </ScrollViewer.Resources>
        <Rectangle Height="800" Fill="Red"/>
    </ScrollViewer>
