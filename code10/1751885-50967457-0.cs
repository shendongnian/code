       <Application.Resources>
            <ResourceDictionary>
                <Style TargetType="Button">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="Button">
                                <Grid x:Name="RootGrid" Background="{TemplateBinding Background}">
                                    <VisualStateManager.VisualStateGroups>
                                        <VisualStateGroup x:Name="CommonStates">
                                            <VisualState x:Name="Normal">
                                                <Storyboard>
                                                    <PointerUpThemeAnimation Storyboard.TargetName="RootGrid" />
                                                </Storyboard>
                                            </VisualState>
                                            <VisualState x:Name="Disabled">
                                                <Storyboard>
                                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="RootGrid"
                                                       Storyboard.TargetProperty="Background">
                                                        <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlBackgroundBaseLowBrush}" />
                                                    </ObjectAnimationUsingKeyFrames>
                                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ContentPresenter"
                                                       Storyboard.TargetProperty="Foreground">
                                                        <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlDisabledBaseMediumLowBrush}" />
                                                    </ObjectAnimationUsingKeyFrames>
                                                    <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ContentPresenter"
                                                       Storyboard.TargetProperty="BorderBrush">
                                                        <DiscreteObjectKeyFrame KeyTime="0" Value="{ThemeResource SystemControlDisabledTransparentBrush}" />
                                                    </ObjectAnimationUsingKeyFrames>
                                                </Storyboard>
                                            </VisualState>
                                        </VisualStateGroup>
                                    </VisualStateManager.VisualStateGroups>
                                    <ContentPresenter x:Name="ContentPresenter"
                              BorderBrush="{TemplateBinding BorderBrush}"
                              BorderThickness="{TemplateBinding BorderThickness}"
                              Content="{TemplateBinding Content}"
                              ContentTransitions="{TemplateBinding ContentTransitions}"
                              ContentTemplate="{TemplateBinding ContentTemplate}"
                              Padding="{TemplateBinding Padding}"
                              HorizontalContentAlignment="{TemplateBinding HorizontalContentAlignment}"
                              VerticalContentAlignment="{TemplateBinding VerticalContentAlignment}"
                              AutomationProperties.AccessibilityView="Raw"/>
                                </Grid>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ResourceDictionary>
        </Application.Resources>
