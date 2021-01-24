    <Window.Resources>
        <!-- set SelectedBackgroundColor to Transparent when you do not need the background in selected items -->
        <Color x:Key="SelectedBackgroundColor">#00FFFFFF</Color>
        <Color x:Key="SelectedUnfocusedColor">#FFB2A3A2</Color>
        <!-- set the MouseOverColor to Transparent when you do not need the effect in the unselected items -->
        <Color x:Key="MouseOverColor" >#00FFFFFF</Color>
        <Style x:Key="ListViewItemStyle"
               TargetType="ListViewItem">
            <Setter Property="SnapsToDevicePixels"
                    Value="true" />
            <Setter Property="OverridesDefaultStyle"
                    Value="true" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ListBoxItem">
                        <Border x:Name="Border"
                                Padding="2"
                                SnapsToDevicePixels="true"
                                Background="Transparent">
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualState x:Name="Normal" />
                                    <VisualState x:Name="MouseOver" >
                                        <Storyboard>
                                            <ColorAnimationUsingKeyFrames Storyboard.TargetName="Border"
                                                                          Storyboard.TargetProperty="(Panel.Background).
                    (SolidColorBrush.Color)">
                                                <EasingColorKeyFrame KeyTime="0"
                                                                     Value="{StaticResource MouseOverColor}" />
                                            </ColorAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="Disabled" />
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="SelectionStates">
                                    <VisualState x:Name="Unselected" />
                                    <VisualState x:Name="Selected">
                                        <Storyboard>
                                            <ColorAnimationUsingKeyFrames Storyboard.TargetName="Border"
                                                                          Storyboard.TargetProperty="(Panel.Background).
                    (SolidColorBrush.Color)">
                                                <EasingColorKeyFrame KeyTime="0"
                                                                     Value="{StaticResource SelectedBackgroundColor}" />
                                            </ColorAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="SelectedUnfocused">
                                        <Storyboard>
                                            <ColorAnimationUsingKeyFrames Storyboard.TargetName="Border"
                                                                          Storyboard.TargetProperty="(Panel.Background).
                    (SolidColorBrush.Color)">
                                                <EasingColorKeyFrame KeyTime="0"
                                                                     Value="{StaticResource SelectedUnfocusedColor}" />
                                            </ColorAnimationUsingKeyFrames>
                                        </Storyboard>
                                    </VisualState>
                                </VisualStateGroup>
                            </VisualStateManager.VisualStateGroups>
                            <ContentPresenter />
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
            <ListView ItemsSource="{Binding Items}"
                      ItemContainerStyle="{StaticResource ListViewItemStyle}">
                <ListView.ItemTemplate>
                    <DataTemplate DataType="local:Item">
                        <StackPanel>
                            <TextBlock Text="{Binding Id}" />
                            <TextBlock Text="{Binding Text}" />
                        </StackPanel>
                    </DataTemplate>
                </ListView.ItemTemplate>
            </ListView>
