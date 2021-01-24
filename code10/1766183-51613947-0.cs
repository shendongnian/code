    <Style x:Key="MyCalendarDayButton"
           TargetType="CalendarDayButton"
           BasedOn="{StaticResource MaterialDesignCalendarDayButton}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type CalendarDayButton}">
                    <Grid>
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="CommonStates">
                                <VisualStateGroup.Transitions>
                                    <VisualTransition From="{x:Null}" GeneratedDuration="0:0:0.1" GeneratedEasingFunction="{x:Null}" Storyboard="{x:Null}" To="{x:Null}"/>
                                </VisualStateGroup.Transitions>
                                <VisualState x:Name="Normal"/>
                                <VisualState x:Name="MouseOver">
                                    <Storyboard>
                                        <DoubleAnimation Duration="0" To="0.5" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="HighlightBackground"/>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="Pressed">
                                    <Storyboard>
                                        <DoubleAnimation Duration="0" To="0.5" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="HighlightBackground"/>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="SelectionStates">
                                <VisualStateGroup.Transitions>
                                    <VisualTransition From="{x:Null}" GeneratedDuration="0" GeneratedEasingFunction="{x:Null}" Storyboard="{x:Null}" To="{x:Null}"/>
                                </VisualStateGroup.Transitions>
                                <VisualState x:Name="Unselected"/>
                                <VisualState x:Name="Selected">
                                    <Storyboard>
                                        <DoubleAnimation Duration="0" To="0.5" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="SelectedBackground"/>
                                        <!--
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(TextElement.Foreground)" Storyboard.TargetName="NormalText">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{DynamicResource PrimaryHueMidForegroundBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        -->
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="CalendarButtonFocusStates">
                                <VisualStateGroup.Transitions>
                                    <VisualTransition From="{x:Null}" GeneratedDuration="0" GeneratedEasingFunction="{x:Null}" Storyboard="{x:Null}" To="{x:Null}"/>
                                </VisualStateGroup.Transitions>
                                <VisualState x:Name="CalendarButtonFocused">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Duration="0" Storyboard.TargetProperty="Visibility" Storyboard.TargetName="DayButtonFocusVisual">
                                            <DiscreteObjectKeyFrame KeyTime="0">
                                                <DiscreteObjectKeyFrame.Value>
                                                    <Visibility>Visible</Visibility>
                                                </DiscreteObjectKeyFrame.Value>
                                            </DiscreteObjectKeyFrame>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                                <VisualState x:Name="CalendarButtonUnfocused">
                                    <Storyboard>
                                        <ObjectAnimationUsingKeyFrames Duration="0" Storyboard.TargetProperty="Visibility" Storyboard.TargetName="DayButtonFocusVisual">
                                            <DiscreteObjectKeyFrame KeyTime="0">
                                                <DiscreteObjectKeyFrame.Value>
                                                    <Visibility>Collapsed</Visibility>
                                                </DiscreteObjectKeyFrame.Value>
                                            </DiscreteObjectKeyFrame>
                                        </ObjectAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="ActiveStates">
                                <VisualStateGroup.Transitions>
                                    <VisualTransition From="{x:Null}" GeneratedDuration="0" GeneratedEasingFunction="{x:Null}" Storyboard="{x:Null}" To="{x:Null}"/>
                                </VisualStateGroup.Transitions>
                                <VisualState x:Name="Active"/>
                                <VisualState x:Name="Inactive"/>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="DayStates">
                                <VisualStateGroup.Transitions>
                                    <VisualTransition From="{x:Null}" GeneratedDuration="0" GeneratedEasingFunction="{x:Null}" Storyboard="{x:Null}" To="{x:Null}"/>
                                </VisualStateGroup.Transitions>
                                <VisualState x:Name="RegularDay"/>
                                <VisualState x:Name="Today">
                                    <Storyboard>
                                        <DoubleAnimation Duration="0" To="1" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="TodayBackground"/>
                                        <!--
                                        <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="(TextElement.Foreground)" Storyboard.TargetName="NormalText">
                                            <DiscreteObjectKeyFrame KeyTime="0" Value="{DynamicResource PrimaryHueLightForegroundBrush}"/>
                                        </ObjectAnimationUsingKeyFrames>
                                        -->
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                            <VisualStateGroup x:Name="BlackoutDayStates">
                                <VisualStateGroup.Transitions>
                                    <VisualTransition From="{x:Null}" GeneratedDuration="0" GeneratedEasingFunction="{x:Null}" Storyboard="{x:Null}" To="{x:Null}"/>
                                </VisualStateGroup.Transitions>
                                <VisualState x:Name="NormalDay"/>
                                <VisualState x:Name="BlackoutDay">
                                    <Storyboard>
                                        <DoubleAnimation Duration="0" To="0" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="HighlightingBorder"/>
                                        <DoubleAnimation Duration="0" To="0.38" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="NormalText"/>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <Ellipse x:Name="TodayBackground" Fill="{DynamicResource PrimaryHueLightBrush}" Opacity="0"/>
                        <Ellipse x:Name="SelectedBackground" Fill="{DynamicResource PrimaryHueMidBrush}" Opacity="0"/>
                        <Border BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}"/>
                        <Border x:Name="HighlightingBorder" Opacity="1">
                            <Ellipse x:Name="HighlightBackground" Fill="{DynamicResource PrimaryHueDarkBrush}" Opacity="0"/>
                        </Border>
                        <ContentPresenter x:Name="NormalText" ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" ContentStringFormat="{TemplateBinding ContentStringFormat}" TextElement.Foreground="{TemplateBinding Foreground}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="5,1" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                        <Ellipse x:Name="DayButtonFocusVisual" Opacity="0" Stroke="{DynamicResource PrimaryHueDarkBrush}" StrokeThickness="1" Visibility="Collapsed"/>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    <Style x:Key="MyCalendarStyle" 
           TargetType="Calendar"
           BasedOn="{StaticResource MaterialDesignDatePickerCalendarPortrait}">
        <Setter Property="CalendarDayButtonStyle" Value="{StaticResource MyCalendarDayButton}"/>
    </Style>
    <Style x:Key="MyDatePickerStyle" 
           TargetType="DatePicker" 
           BasedOn="{StaticResource MaterialDesignDatePicker}">
        <Setter Property="CalendarStyle" Value="{StaticResource MyCalendarStyle}"/>
    </Style>    
