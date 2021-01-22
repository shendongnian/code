    <Application.Resources>
            <ControlTemplate x:Key="PhoneDisabledTextBoxTemplate" TargetType="TextBox">
                <ContentControl x:Name="ContentElement" BorderThickness="0" HorizontalContentAlignment="Stretch" Margin="{StaticResource PhoneTextBoxInnerMargin}" Padding="{TemplateBinding Padding}" VerticalContentAlignment="Stretch"/>
            </ControlTemplate>
            <Style x:Key="TextBoxStyle1" TargetType="TextBox">
                <Setter Property="FontFamily" Value="{StaticResource PhoneFontFamilyNormal}"/>
                <Setter Property="FontSize" Value="{StaticResource PhoneFontSizeMediumLarge}"/>
                <Setter Property="Background" Value="{StaticResource PhoneTextBoxBrush}"/>
                <Setter Property="Foreground" Value="{StaticResource PhoneTextBoxForegroundBrush}"/>
                <Setter Property="BorderBrush" Value="{StaticResource PhoneTextBoxBrush}"/>
                <Setter Property="SelectionBackground" Value="{StaticResource PhoneAccentBrush}"/>
                <Setter Property="SelectionForeground" Value="{StaticResource PhoneTextBoxSelectionForegroundBrush}"/>
                <Setter Property="BorderThickness" Value="{StaticResource PhoneBorderThickness}"/>
                <Setter Property="Padding" Value="2"/>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="TextBox">
                            <Grid Background="Transparent">
                                <VisualStateManager.VisualStateGroups>
                                    <VisualStateGroup x:Name="CommonStates" ec:ExtendedVisualStateManager.UseFluidLayout="True">
                                        <VisualState x:Name="Normal"/>
                                        <VisualState x:Name="MouseOver"/>
                                        <VisualState x:Name="Disabled">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="EnabledBorder">
                                                    <DiscreteObjectKeyFrame KeyTime="0">
                                                        <DiscreteObjectKeyFrame.Value>
                                                            <Visibility>Collapsed</Visibility>
                                                        </DiscreteObjectKeyFrame.Value>
                                                    </DiscreteObjectKeyFrame>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="ReadOnly">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="EnabledBorder">
                                                    <DiscreteObjectKeyFrame KeyTime="0">
                                                        <DiscreteObjectKeyFrame.Value>
                                                            <Visibility>Collapsed</Visibility>
                                                        </DiscreteObjectKeyFrame.Value>
                                                    </DiscreteObjectKeyFrame>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                    </VisualStateGroup>
                                    <VisualStateGroup x:Name="FocusStates">
                                        <VisualState x:Name="Focused">
                                            <Storyboard>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Background" Storyboard.TargetName="EnabledBorder">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneTextBoxEditBackgroundBrush}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                                <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="BorderBrush" Storyboard.TargetName="EnabledBorder">
                                                    <DiscreteObjectKeyFrame KeyTime="0" Value="{StaticResource PhoneTextBoxEditBorderBrush}"/>
                                                </ObjectAnimationUsingKeyFrames>
                                            </Storyboard>
                                        </VisualState>
                                        <VisualState x:Name="Unfocused"/>
                                    </VisualStateGroup>
                                </VisualStateManager.VisualStateGroups>
                                <VisualStateManager.CustomVisualStateManager>
                                    <ec:ExtendedVisualStateManager/>
                                </VisualStateManager.CustomVisualStateManager>
                                <Border x:Name="EnabledBorder" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Margin="{StaticResource PhoneTouchTargetOverhang}">
                                    <ContentControl x:Name="ContentElement" BorderThickness="0" HorizontalContentAlignment="Stretch" Margin="{StaticResource PhoneTextBoxInnerMargin}" Padding="{TemplateBinding Padding}" VerticalContentAlignment="Stretch"/>
                                </Border>
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Application.Resources>
