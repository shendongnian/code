        <Window.Resources>
        <Style x:Key="CustomCalendar" TargetType="{x:Type Calendar}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type Calendar}">
                        <Viewbox Height="300" Width="300" >
                            <CalendarItem x:Name="PART_CalendarItem" 
                                  Background="{TemplateBinding Background}"
                                  BorderBrush="{TemplateBinding BorderBrush}"
                                  BorderThickness="{TemplateBinding BorderThickness}" FontStretch="Expanded">
                            </CalendarItem>
                        </Viewbox>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Setter Property="CalendarDayButtonStyle">
                <Setter.Value>
                    <Style TargetType="{x:Type CalendarDayButton}">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type CalendarDayButton}">
                                    <Grid>
                                        <VisualStateManager.VisualStateGroups>
                                            <VisualStateGroup x:Name="CommonStates">
                                                <VisualStateGroup.Transitions>
                                                    <VisualTransition GeneratedDuration="0:0:0.1"/>
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
                                                <VisualState x:Name="Disabled">
                                                    <Storyboard>
                                                        <DoubleAnimation Duration="0" To="0" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="HighlightBackground"/>
                                                        <DoubleAnimation Duration="0" To=".35" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="NormalText"/>
                                                    </Storyboard>
                                                </VisualState>
                                            </VisualStateGroup>
                                            <VisualStateGroup x:Name="SelectionStates">
                                                <VisualStateGroup.Transitions>
                                                    <VisualTransition GeneratedDuration="0"/>
                                                </VisualStateGroup.Transitions>
                                                <VisualState x:Name="Unselected"/>
                                                <VisualState x:Name="Selected">
                                                    <Storyboard>
                                                        <DoubleAnimation Duration="0" To=".75" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="SelectedBackground"/>
                                                    </Storyboard>
                                                </VisualState>
                                            </VisualStateGroup>
                                            <VisualStateGroup x:Name="CalendarButtonFocusStates">
                                                <VisualStateGroup.Transitions>
                                                    <VisualTransition GeneratedDuration="0"/>
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
                                                    <VisualTransition GeneratedDuration="0"/>
                                                </VisualStateGroup.Transitions>
                                                <VisualState x:Name="Active"/>
                                                <VisualState x:Name="Inactive">
                                                    <Storyboard>
                                                        <ColorAnimation Duration="0" To="#FF777777" Storyboard.TargetProperty="(TextElement.Foreground).(SolidColorBrush.Color)" Storyboard.TargetName="NormalText"/>
                                                    </Storyboard>
                                                </VisualState>
                                            </VisualStateGroup>
                                            <VisualStateGroup x:Name="DayStates">
                                                <VisualStateGroup.Transitions>
                                                    <VisualTransition GeneratedDuration="0"/>
                                                </VisualStateGroup.Transitions>
                                                <VisualState x:Name="RegularDay"/>
                                                <VisualState x:Name="Today">
                                                    <Storyboard>
                                                        <DoubleAnimation Duration="0" To="1" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="TodayBackground"/>
                                                        <ColorAnimation Duration="0" To="#FFFFFFFF" Storyboard.TargetProperty="(TextElement.Foreground).(SolidColorBrush.Color)" Storyboard.TargetName="NormalText"/>
                                                    </Storyboard>
                                                </VisualState>
                                            </VisualStateGroup>
                                            <VisualStateGroup x:Name="BlackoutDayStates">
                                                <VisualStateGroup.Transitions>
                                                    <VisualTransition GeneratedDuration="0"/>
                                                </VisualStateGroup.Transitions>
                                                <VisualState x:Name="NormalDay"/>
                                                <VisualState x:Name="BlackoutDay">
                                                    <Storyboard>
                                                        <DoubleAnimation Duration="0" To=".2" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="Blackout"/>
                                                    </Storyboard>
                                                </VisualState>
                                            </VisualStateGroup>
                                        </VisualStateManager.VisualStateGroups>
                                        <Rectangle x:Name="TodayBackground" Fill="#FFAAAAAA" Opacity="0" RadiusY="1" RadiusX="1"/>
                                        <Rectangle x:Name="SelectedBackground" Fill="#FFBADDE9" Opacity="0" RadiusY="1" RadiusX="1"/>
                                        <Border BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}"/>
                                        <Rectangle x:Name="HighlightBackground" Fill="Red" Opacity="0" RadiusY="1" RadiusX="1"/>
                                        <ContentPresenter x:Name="NormalText" TextElement.Foreground="#FF333333" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="5,1,5,1" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                                        <Path x:Name="Blackout" Data="M8.1772461,11.029181 L10.433105,11.029181 L11.700684,12.801641 L12.973633,11.029181 L15.191895,11.029181 L12.844727,13.999395 L15.21875,17.060919 L12.962891,17.060919 L11.673828,15.256231 L10.352539,17.060919 L8.1396484,17.060919 L10.519043,14.042364 z" Fill="#FF000000" HorizontalAlignment="Stretch" Margin="3" Opacity="0" RenderTransformOrigin="0.5,0.5" Stretch="Fill" VerticalAlignment="Stretch"/>
                                        <Rectangle x:Name="DayButtonFocusVisual" IsHitTestVisible="false" RadiusY="1" RadiusX="1" Stroke="Red" Visibility="Collapsed"/>
                                    </Grid>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </Setter.Value>
            </Setter>
            <Setter Property="CalendarButtonStyle">
                <Setter.Value>
                    <Style TargetType="{x:Type CalendarButton}">
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type CalendarButton}">
                                    <Grid>
                                        <VisualStateManager.VisualStateGroups>
                                            <VisualStateGroup x:Name="CommonStates">
                                                <VisualStateGroup.Transitions>
                                                    <VisualTransition GeneratedDuration="0:0:0.1"/>
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
                                                <VisualState x:Name="Disabled">
                                                    <Storyboard>
                                                        <DoubleAnimation Duration="0" To="0" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="HighlightBackground"/>
                                                        <DoubleAnimation Duration="0" To=".35" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="NormalText"/>
                                                    </Storyboard>
                                                </VisualState>
                                            </VisualStateGroup>
                                            <VisualStateGroup x:Name="SelectionStates">
                                                <VisualStateGroup.Transitions>
                                                    <VisualTransition GeneratedDuration="0"/>
                                                </VisualStateGroup.Transitions>
                                                <VisualState x:Name="Unselected"/>
                                                <VisualState x:Name="Selected">
                                                    <Storyboard>
                                                        <DoubleAnimation Duration="0" To=".75" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="SelectedBackground"/>
                                                    </Storyboard>
                                                </VisualState>
                                            </VisualStateGroup>
                                            <VisualStateGroup x:Name="CalendarButtonFocusStates">
                                                <VisualStateGroup.Transitions>
                                                    <VisualTransition GeneratedDuration="0"/>
                                                </VisualStateGroup.Transitions>
                                                <VisualState x:Name="CalendarButtonFocused">
                                                    <Storyboard>
                                                        <ObjectAnimationUsingKeyFrames Duration="0" Storyboard.TargetProperty="Visibility" Storyboard.TargetName="ButtonFocusVisual">
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
                                                        <ObjectAnimationUsingKeyFrames Duration="0" Storyboard.TargetProperty="Visibility" Storyboard.TargetName="ButtonFocusVisual">
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
                                                    <VisualTransition GeneratedDuration="0"/>
                                                </VisualStateGroup.Transitions>
                                                <VisualState x:Name="Active"/>
                                                <VisualState x:Name="Inactive">
                                                    <Storyboard>
                                                        <ColorAnimation Duration="0" To="#FF777777" Storyboard.TargetProperty="(TextElement.Foreground).(SolidColorBrush.Color)" Storyboard.TargetName="NormalText"/>
                                                    </Storyboard>
                                                </VisualState>
                                            </VisualStateGroup>
                                            <VisualStateGroup x:Name="DayStates">
                                                <VisualStateGroup.Transitions>
                                                    <VisualTransition GeneratedDuration="0"/>
                                                </VisualStateGroup.Transitions>
                                                <VisualState x:Name="RegularDay"/>
                                                <VisualState x:Name="Today">
                                                    <Storyboard>
                                                        <DoubleAnimation Duration="0" To="1" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="TodayBackground"/>
                                                        <ColorAnimation Duration="0" To="#FFFFFFFF" Storyboard.TargetProperty="(TextElement.Foreground).(SolidColorBrush.Color)" Storyboard.TargetName="NormalText"/>
                                                    </Storyboard>
                                                </VisualState>
                                            </VisualStateGroup>
                                            <VisualStateGroup x:Name="BlackoutDayStates">
                                                <VisualStateGroup.Transitions>
                                                    <VisualTransition GeneratedDuration="0"/>
                                                </VisualStateGroup.Transitions>
                                                <VisualState x:Name="NormalDay"/>
                                                <VisualState x:Name="BlackoutDay">
                                                    <Storyboard>
                                                        <DoubleAnimation Duration="0" To=".2" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="Blackout"/>
                                                    </Storyboard>
                                                </VisualState>
                                            </VisualStateGroup>
                                        </VisualStateManager.VisualStateGroups>
                                        <Rectangle x:Name="TodayBackground" Fill="Red" Opacity="0" RadiusY="1" RadiusX="1"/>
                                        <Rectangle x:Name="SelectedBackground" Fill="Red" Opacity="0" RadiusY="1" RadiusX="1"/>
                                        <Border BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="#F6F9FB"/>
                                        <Rectangle x:Name="HighlightBackground" Fill="Red" Opacity="0" RadiusY="1" RadiusX="1"/>
                                        <ContentPresenter x:Name="NormalText" TextElement.Foreground="Black" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="5,1,5,1" VerticalAlignment="{TemplateBinding VerticalContentAlignment}"/>
                                        <Path x:Name="Blackout" Data="M8.1772461,11.029181 L10.433105,11.029181 L11.700684,12.801641 L12.973633,11.029181 L15.191895,11.029181 L12.844727,13.999395 L15.21875,17.060919 L12.962891,17.060919 L11.673828,15.256231 L10.352539,17.060919 L8.1396484,17.060919 L10.519043,14.042364 z" Fill="#FF000000" HorizontalAlignment="Stretch" Margin="3" Opacity="0" RenderTransformOrigin="0.5,0.5" Stretch="Fill" VerticalAlignment="Stretch"/>
                                        <Rectangle x:Name="ButtonFocusVisual" IsHitTestVisible="false" RadiusY="1" RadiusX="1" Stroke="Red" Visibility="Collapsed"/>
                                    </Grid>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
