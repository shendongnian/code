    <ResourceDictionary xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:Themes="clr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Classic" 
        xmlns:System="clr-namespace:System;assembly=mscorlib">
    
    <Style x:Key="TT_Popup" TargetType="Popup">
            <Setter Property="VerticalOffset" Value="20" />
            <Setter Property="MaxWidth" Value="500" />
            <Setter Property="MinWidth" Value="50" />
            <Style.Triggers>
                <DataTrigger Binding="{Binding PlacementTarget.IsMouseOver, RelativeSource={RelativeSource Self}}" Value="True">
                    <DataTrigger.EnterActions>
                        <BeginStoryboard x:Name="OpenPopupStoryBoard" >
                            <Storyboard>
                                <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsOpen" FillBehavior="HoldEnd">
                                    <DiscreteBooleanKeyFrame KeyTime="0:0:1.00" Value="True"/>
                                </BooleanAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </DataTrigger.EnterActions>
                    <DataTrigger.ExitActions>
                        <PauseStoryboard BeginStoryboardName="OpenPopupStoryBoard"/>
                        <BeginStoryboard x:Name="ClosePopupStoryBoard">
                            <Storyboard>
                                <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsOpen" FillBehavior="HoldEnd">
                                    <DiscreteBooleanKeyFrame KeyTime="0:0:0.35" Value="False"/>
                                </BooleanAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </DataTrigger.ExitActions>
                </DataTrigger>
                <DataTrigger Binding="{Binding PlacementTarget.IsMouseCaptured, RelativeSource={RelativeSource Self}}" Value="True">
                    <DataTrigger.EnterActions>
                        <PauseStoryboard BeginStoryboardName="OpenPopupStoryBoard"/>
                        <BeginStoryboard x:Name="CloseImmediatelyPopupStoryBoard" >
                            <Storyboard>
                                <BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsOpen" FillBehavior="HoldEnd">
                                    <DiscreteBooleanKeyFrame KeyTime="0:0:0.0" Value="False"/>
                                </BooleanAnimationUsingKeyFrames>
                            </Storyboard>
                        </BeginStoryboard>
                    </DataTrigger.EnterActions>
                </DataTrigger>
                <DataTrigger Binding="{Binding PlacementTarget.IsMouseOver, RelativeSource={RelativeSource Self}}" Value="False">
                    <DataTrigger.ExitActions>
                        <RemoveStoryboard BeginStoryboardName="CloseImmediatelyPopupStoryBoard" />
                    </DataTrigger.ExitActions>
                </DataTrigger>
                
                <Trigger Property="IsMouseOver" Value="True">
                    <Trigger.EnterActions>
                        <PauseStoryboard BeginStoryboardName="ClosePopupStoryBoard" />
                    </Trigger.EnterActions>
                    <Trigger.ExitActions>
                        <PauseStoryboard BeginStoryboardName="OpenPopupStoryBoard"/>
                        <ResumeStoryboard BeginStoryboardName="ClosePopupStoryBoard" />
                    </Trigger.ExitActions>
                </Trigger>
            </Style.Triggers>
        </Style>
    </ResourceDictionary>
