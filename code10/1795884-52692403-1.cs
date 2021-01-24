    <Storyboard x:Name="topbagroundfadeinout">
        <ColorAnimationUsingKeyFrames Storyboard.TargetName="topcmdbar" 
         Storyboard.TargetProperty="(CommandBar.Background).(SolidColorBrush.Color)">
            <EasingColorKeyFrame KeyTime="0" Value="#00000000" />
            <EasingColorKeyFrame KeyTime="0:0:1" Value="Black" />
            <EasingColorKeyFrame KeyTime="0:0:4" Value="Black" />
            <EasingColorKeyFrame KeyTime="0:0:6" Value="#00000000" />
        </ColorAnimationUsingKeyFrames>
    </Storyboard>
