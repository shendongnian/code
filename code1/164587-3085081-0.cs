    <VisualStateManager.VisualStateGroups>
    								<VisualStateGroup x:Name="CommonStates">
    									<VisualState x:Name="Normal"/>
    									<VisualState x:Name="MouseOver">
    										<Storyboard>
    											<ColorAnimationUsingKeyFrames BeginTime="00:00:00" Storyboard.TargetName="Background" Storyboard.TargetProperty="(Border.Background).(SolidColorBrush.Color)">
    												<EasingColorKeyFrame KeyTime="00:00:00" Value="White"/>
    												<EasingColorKeyFrame KeyTime="00:00:01" Value="Red"/>
    											</ColorAnimationUsingKeyFrames>
    										</Storyboard>
    									</VisualState>
    								</VisualStateGroup>
    									<VisualState x:Name="Pressed" />
    									<VisualState x:Name="Disabled" />
    								</VisualStateGroup>
    							</VisualStateManager.VisualStateGroups>
