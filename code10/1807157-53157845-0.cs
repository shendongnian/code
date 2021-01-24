    <Storyboard x:Key="MenuOpen">
        <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.Width)" Storyboard.TargetName="GridMenu">
            <EasingDoubleKeyFrame KeyTime="0" Value="50"/>
            <EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="150"/>
        </DoubleAnimationUsingKeyFrames>
    </Storyboard>
    <Storyboard x:Key="MenuClose">
        <DoubleAnimationUsingKeyFrames Storyboard.TargetProperty="(FrameworkElement.Width)" Storyboard.TargetName="GridMenu">
            <EasingDoubleKeyFrame KeyTime="0" Value="150"/>
            <EasingDoubleKeyFrame KeyTime="0:0:0.5" Value="50"/>
        </DoubleAnimationUsingKeyFrames>
    </Storyboard>
    <EventTrigger x:Key="et" RoutedEvent="ButtonBase.Click" SourceName="btnOpenMenu">
        <BeginStoryboard Storyboard="{StaticResource MenuOpen}"/>
    </EventTrigger>
    <EventTrigger x:Key="et2" RoutedEvent="ButtonBase.Click" SourceName="btnCloseMenu">
        <BeginStoryboard Storyboard="{StaticResource MenuClose}"/>
    </EventTrigger>
