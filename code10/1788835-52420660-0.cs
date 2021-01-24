    <ControlTemplate.Triggers>
        <Trigger Property="local:MouseDownHelper.IsMouseLeftButtonDown"
                 Value="True">
            <Trigger.EnterActions>
                <StopStoryboard BeginStoryboardName="StoryboardEnter"/>
                <BeginStoryboard>
                    <Storyboard>
                        <ColorAnimation Duration="00:00:00.000"
                                        Storyboard.TargetName="SendReportsButtonMainGrid"
                                        Storyboard.TargetProperty="Background.Color"
                                        To="{StaticResource HoverGray}" />
                        <ColorAnimation Duration="00:00:00.100"
                                        Storyboard.TargetName="SendReportsButtonMainGrid"
                                        Storyboard.TargetProperty="Background.Color"
                                        To="{StaticResource ClickGray}" />
                    </Storyboard>
                </BeginStoryboard>
            </Trigger.EnterActions>
            <Trigger.ExitActions>
                <BeginStoryboard>
                    <Storyboard>
                        <ColorAnimation Duration="00:00:00.100"
                                        Storyboard.TargetName="SendReportsButtonMainGrid"
                                        Storyboard.TargetProperty="Background.Color"
                                        To="{StaticResource HoverGray}" />
                    </Storyboard>
                </BeginStoryboard>
            </Trigger.ExitActions>
        </Trigger>
        <EventTrigger RoutedEvent="MouseEnter">
            <BeginStoryboard Name="StoryboardEnter">
                <Storyboard>
                    <ColorAnimation Duration="00:00:00.200"
                                    Storyboard.TargetName="SendReportsButtonMainGrid"
                                    Storyboard.TargetProperty="Background.Color"
                                    To="{StaticResource HoverGray}" />
                </Storyboard>
            </BeginStoryboard>
        </EventTrigger>
        <EventTrigger RoutedEvent="MouseLeave">
            <BeginStoryboard>
                <Storyboard>
                    <ColorAnimation Duration="00:00:00.400"
                                    Storyboard.TargetName="SendReportsButtonMainGrid"
                                    Storyboard.TargetProperty="Background.Color"
                                    To="{StaticResource HeaderGray}" />
                </Storyboard>
            </BeginStoryboard>
        </EventTrigger>
    </ControlTemplate.Triggers>
