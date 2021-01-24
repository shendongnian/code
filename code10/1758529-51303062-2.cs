    <Style TargetType="basic:SecurePage">
        <Setter Property="FontSize" Value="14"/>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="basic:SecurePage">
                    <Grid x:Name="Grid">
                        <VisualStateManager.VisualStateGroups>
                            <VisualStateGroup x:Name="Signals">
                                <VisualState x:Name="Normal"/>
                                <VisualState x:Name="Blink">
                                    <Storyboard>
                                        <ColorAnimationUsingKeyFrames Storyboard.TargetProperty="(Border.BorderBrush).(SolidColorBrush.Color)" Storyboard.TargetName="border">
                                            <EasingColorKeyFrame KeyTime="0:0:0.4" Value="#FF3AFF00">
                                                <EasingColorKeyFrame.EasingFunction>
                                                    <BounceEase EasingMode="EaseIn" Bounciness="3" Bounces="4"/>
                                                </EasingColorKeyFrame.EasingFunction>
                                            </EasingColorKeyFrame>
                                        </ColorAnimationUsingKeyFrames>
                                    </Storyboard>
                                </VisualState>
                            </VisualStateGroup>
                        </VisualStateManager.VisualStateGroups>
                        <ContentPresenter Content="{TemplateBinding Content}"/>
                        <Border 
                            x:Name="border"
                            BorderThickness="5"
                            BorderBrush="Transparent"
                            IsHitTestVisible="False"/>
                        <i:Interaction.Triggers>                            
                            <ei:DataTrigger Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=basic:SecurePage}, Path=VisualState}" Value="{x:Static basic:ESecurePageVisualState.Normal}">
                                <ei:GoToStateAction StateName="Normal" TargetName="Grid" TargetObject="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Grid}}"/>
                            </ei:DataTrigger>
                            <ei:DataTrigger Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=basic:SecurePage}, Path=VisualState}" Value="{x:Static basic:ESecurePageVisualState.Blink}">
                                <ei:GoToStateAction StateName="Blink" TargetName="Grid" TargetObject="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=Grid}}"/>
                            </ei:DataTrigger>
                        </i:Interaction.Triggers>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
