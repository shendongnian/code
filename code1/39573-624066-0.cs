    <Button Margin="0,0,0,0" Content="Button" Grid.Row="0" x:Name="BtnLeft" Style="{DynamicResource ButtonStyle1}">
        <Button.Resources>
            <Storyboard x:Key="OnMouseEnter1">
                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00"
                    Storyboard.TargetName="BtnRight"
                    Storyboard.TargetProperty="Width">
                    <SplineDoubleKeyFrame KeyTime="00:00:00.5" Value="75"/>
                </DoubleAnimationUsingKeyFrames>
            </Storyboard>
            <Storyboard x:Key="OnMouseLeave1">
                <DoubleAnimationUsingKeyFrames BeginTime="00:00:00" 
                    Storyboard.TargetName="BtnRight" 
                    Storyboard.TargetProperty="Width">
                    <SplineDoubleKeyFrame KeyTime="00:00:00.5" Value="0"/>
                </DoubleAnimationUsingKeyFrames>
            </Storyboard>
        </Button.Resources>
        <Button.Triggers>
            <EventTrigger RoutedEvent="Mouse.MouseEnter" SourceName="BtnLeft">
                <BeginStoryboard Storyboard="{StaticResource OnMouseEnter1}"/>
            </EventTrigger>
            <EventTrigger RoutedEvent="Mouse.MouseLeave" SourceName="BtnLeft">
                <BeginStoryboard Storyboard="{StaticResource OnMouseLeave1}"/>
            </EventTrigger>
        </Button.Triggers>
    </Button>
