    <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ButtonBase">
                        <Grid>
                            <Grid.Resources>
                                <Storyboard x:Key="MouseOverStoryboard">
                                    <ColorAnimationUsingKeyFrames Storyboard.TargetName="Bd"
                                                                  Storyboard.TargetProperty="Background.Color">
                                        <EasingColorKeyFrame KeyTime="0" Value="{Binding Path=(theming:MouseOverProperties.BackgroundColor), RelativeSource={RelativeSource TemplatedParent}}" />
                                    </ColorAnimationUsingKeyFrames>
                                    <ColorAnimationUsingKeyFrames Storyboard.TargetName="Bd"
                                                                  Storyboard.TargetProperty="BorderBrush.Color">
                                        <EasingColorKeyFrame KeyTime="0" Value="{Binding Path=(theming:MouseOverProperties.BorderColor), RelativeSource={RelativeSource TemplatedParent}}" />
                                    </ColorAnimationUsingKeyFrames>
                                </Storyboard>
                                <Storyboard x:Key="PressedStoryboard">
                                    <ColorAnimationUsingKeyFrames Storyboard.TargetName="Bd"
                                                                  Storyboard.TargetProperty="Background.Color">
                                        <DiscreteColorKeyFrame KeyTime="0" Value="{Binding Path=(theming:MouseOverProperties.BackgroundColor), RelativeSource={RelativeSource TemplatedParent}}" />
                                    </ColorAnimationUsingKeyFrames>
                                    <ColorAnimationUsingKeyFrames Storyboard.TargetName="Bd"
                                                                  Storyboard.TargetProperty="BorderBrush.Color">
                                        <DiscreteColorKeyFrame KeyTime="0" Value="{Binding Path=(theming:MouseOverProperties.BorderColor), RelativeSource={RelativeSource TemplatedParent}}" />
                                    </ColorAnimationUsingKeyFrames>
                                </Storyboard>
                                <Storyboard x:Key="DisabledStoryboard">
                                    <ColorAnimationUsingKeyFrames Storyboard.TargetName="Bd"
                                                                  Storyboard.TargetProperty="Background.Color">
                                        <EasingColorKeyFrame KeyTime="0" Value="{Binding Path=(theming:DisabledProperties.BackgroundColor), RelativeSource={RelativeSource TemplatedParent}}" />
                                    </ColorAnimationUsingKeyFrames>
                                    <ColorAnimationUsingKeyFrames Storyboard.TargetName="Bd"
                                                                  Storyboard.TargetProperty="BorderBrush.Color">
                                        <EasingColorKeyFrame KeyTime="0" Value="{Binding Path=(theming:DisabledProperties.BorderColor), RelativeSource={RelativeSource TemplatedParent}}" />
                                    </ColorAnimationUsingKeyFrames>
                                </Storyboard>
                            </Grid.Resources>
                            
                            <!-- ... -->
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualStateGroup.Transitions>
                                        <VisualTransition GeneratedDuration="{StaticResource ColorAnimationDuration}" />
                                        <VisualTransition To="Disabled" GeneratedDuration="0" />
                                    </VisualStateGroup.Transitions>
                                    <VisualState x:Name="Normal" />
                                    <VisualState x:Name="MouseOver" Storyboard="{StaticResource MouseOverStoryboard}" />
                                    <VisualState x:Name="Pressed" Storyboard="{StaticResource PressedStoryboard}" />
                                    <VisualState x:Name="Disabled" Storyboard="{StaticResource DisabledStoryboard}" />
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                        </Grid>
                    </ControlTemplate>
                </Setter.Value>
