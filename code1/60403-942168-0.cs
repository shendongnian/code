    <DataTemplate.Triggers>
        <EventTrigger
            SourceName="BorderControl"
            RoutedEvent="TextBlock.MouseEnter">
            <BeginStoryboard>
                <Storyboard>
                    <ColorAnimation Storyboard.TargetName="BorderControl"
                        Storyboard.TargetProperty="Background.Color"
                        To="DarkRed" Duration="00:00:00.2" />
                </Storyboard>
            </BeginStoryboard>
        </EventTrigger>
        <EventTrigger
            SourceName="BorderControl"
            RoutedEvent="TextBlock.MouseLeave">
            <BeginStoryboard>
                <Storyboard>
                    <ColorAnimation Storyboard.TargetName="BorderControl"
                        Storyboard.TargetProperty="Background.Color"
                        To="WhiteSmoke" Duration="00:00:00.2" />
                </Storyboard>
            </BeginStoryboard>
        </EventTrigger>
    </DataTemplate.Triggers>
