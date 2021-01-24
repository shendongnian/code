    <Window.Resources>
        <Style x:Key="ds_NotificationStyle" TargetType="DockPanel">
            <Setter Property="Opacity" Value="0" />
            <Setter Property="Visibility" Value="Collapsed" />
            <Style.Triggers>
                <DataTrigger Binding="{Binding EnableNotification}" Value="True">
                    <DataTrigger.EnterActions>
                        <BeginStoryboard Name="ds_BeginCallNotification">
                            <Storyboard>
                                <ObjectAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetProperty="Visibility">
                                    <DiscreteObjectKeyFrame KeyTime="00:00:00" Value="{x:Static Visibility.Visible}"/>
                                </ObjectAnimationUsingKeyFrames>
                                <DoubleAnimation Storyboard.TargetProperty="Opacity" From="0" To="1" Duration="0:0:0.2" />
                                <DoubleAnimation Storyboard.TargetProperty="Opacity" From="1" To="0.4" Duration="0:0:0.4" AutoReverse="True" RepeatBehavior="Forever" />
                            </Storyboard>
                        </BeginStoryboard>
                    </DataTrigger.EnterActions>
                    <DataTrigger.ExitActions>
                        <StopStoryboard BeginStoryboardName="ds_BeginCallNotification" />
                        <BeginStoryboard>
                            <Storyboard>
                                <DoubleAnimation Storyboard.TargetProperty="Opacity" From="1" To="0" Duration="00:00:00.2" />
                                <ObjectAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetProperty="Visibility">
                                    <DiscreteObjectKeyFrame KeyTime="00:00:00" Value="{x:Static Visibility.Collapsed}" />
                                </ObjectAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </DataTrigger.ExitActions>
                </DataTrigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
