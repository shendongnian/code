     <UserControl.Resources>
            <Style x:Key="CustomListBoxItemStyle" TargetType="ChargeEntry:CustomListBoxItem">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ChargeEntry:CustomListBoxItem">
                            <Grid Background="{TemplateBinding Background}">
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="CommonStates">
                                        <VisualState x:Name="Normal"/>
                                        <VisualState x:Name="MouseOver">
                                            <Storyboard>
                                                <DoubleAnimation Duration="0" To=".35" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="fillColor"/>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="Disabled">
                                            <Storyboard>
                                                <DoubleAnimation Duration="0" To=".55" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="contentPresenter"/>
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                    <VisualStateGroup x:Name="SelectionStates">
                                        <VisualState x:Name="Unselected"/>
                                        <VisualState x:Name="Selected">
                                            <Storyboard>
                                                <DoubleAnimation Duration="0" To=".75" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="fillColor2"/>
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                    <VisualStateGroup x:Name="FocusStates">
                                        <VisualState x:Name="Focused">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Duration="0" Storyboard.TargetProperty="Visibility" Storyboard.TargetName="FocusVisualElement">
                                                    <DiscreteObjectKeyFrame KeyTime="0">
                                                        <DiscreteObjectKeyFrame.Value>
                                                            <Visibility>Visible</Visibility>
                                                        </DiscreteObjectKeyFrame.Value>
                                                    </DiscreteObjectKeyFrame>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="Unfocused"/>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                                <Grid HorizontalAlignment="Stretch">
                                    <TextBlock x:Name="txtName" />
                                </Grid>
                                <Rectangle x:Name="fillColor" Fill="#FFBADDE9" IsHitTestVisible="False" Opacity="0" RadiusY="1" RadiusX="1"/>
                                <Rectangle x:Name="fillColor2" Fill="#FFBADDE9" IsHitTestVisible="False" Opacity="0" RadiusY="1" RadiusX="1"/>
                                <ContentPresenter x:Name="contentPresenter" ContentTemplate="{TemplateBinding ContentTemplate}" Content="{TemplateBinding Content}" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" Margin="{TemplateBinding Padding}"/>
                                <Rectangle x:Name="FocusVisualElement" RadiusY="1" RadiusX="1" Stroke="#FF6DBDD1" StrokeThickness="1" Visibility="Collapsed"/>
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
    
        </UserControl.Resources>
