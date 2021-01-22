        <Button>
            <Button.Style>
                <Style TargetType="Button">
                    <Setter Property="Width" Value="50" />
                    <Setter Property="Height" Value="20" />
                    <Style.Triggers>
                        <EventTrigger RoutedEvent="MouseEnter">
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation Storyboard.TargetProperty="Width" To="100" />
                                    <DoubleAnimation Storyboard.TargetProperty="Height" To="40" />
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                        <EventTrigger RoutedEvent="MouseLeave">
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation Storyboard.TargetProperty="Width" To="50" />
                                    <DoubleAnimation Storyboard.TargetProperty="Height" To="20" />
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
