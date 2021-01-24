    <ContentControl x:Name="ContentControl" 
                    x:Class="Question_Answer_WPF_App.FlyoutControl"
                    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                    Template="{DynamicResource ContentControlTemplate}"
                    Opacity="0"
                    Visibility="Hidden">
    
        <ContentControl.Resources>
    
            <Duration x:Key="OpenDuration">00:00:00.4</Duration>
    
            <Storyboard x:Key="OpenStoryboard" Duration="{StaticResource OpenDuration}">
                <DoubleAnimation Storyboard.TargetName="ContentControl" Storyboard.TargetProperty="Opacity" To="1" Duration="{StaticResource OpenDuration}">
                    <DoubleAnimation.EasingFunction>
                        <BackEase EasingMode="EaseOut" Amplitude="0.4"/>
                    </DoubleAnimation.EasingFunction>
                </DoubleAnimation>
                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ContentControl" Storyboard.TargetProperty="Visibility" Duration="{StaticResource OpenDuration}">
                    <DiscreteObjectKeyFrame Value="{x:Static Visibility.Visible}" KeyTime="00:00:00" />
                </ObjectAnimationUsingKeyFrames>
            </Storyboard>
    
            <Storyboard x:Key="OpenInnerContentStoryboard" Duration="{StaticResource OpenDuration}">
                <DoubleAnimation Storyboard.TargetName="scaleTransform" Storyboard.TargetProperty="ScaleX" To="1" Duration="{StaticResource OpenDuration}">
                    <DoubleAnimation.EasingFunction>
                        <BackEase EasingMode="EaseOut" Amplitude="0.4"/>
                    </DoubleAnimation.EasingFunction>
                </DoubleAnimation>
    
                <DoubleAnimation Storyboard.TargetName="scaleTransform" Storyboard.TargetProperty="ScaleY" To="1" Duration="{StaticResource OpenDuration}">
                    <DoubleAnimation.EasingFunction>
                        <BackEase EasingMode="EaseOut" Amplitude="0.4"/>
                    </DoubleAnimation.EasingFunction>
                </DoubleAnimation>
            </Storyboard>
    
            <Storyboard x:Key="CloseStoryboard">
                <DoubleAnimation Storyboard.TargetName="ContentControl" Storyboard.TargetProperty="Opacity" To="0" Duration="00:00:00"/>
                <ObjectAnimationUsingKeyFrames Storyboard.TargetName="ContentControl" Storyboard.TargetProperty="Visibility">
                    <DiscreteObjectKeyFrame Value="{x:Static Visibility.Hidden}" KeyTime="00:00:00" />
                </ObjectAnimationUsingKeyFrames>
            </Storyboard>
    
            <Storyboard x:Key="CloseInnerContentStoryboard">
                <DoubleAnimation Storyboard.TargetName="scaleTransform" Storyboard.TargetProperty="ScaleX" To="0" Duration="00:00:00"/>
                <DoubleAnimation Storyboard.TargetName="scaleTransform" Storyboard.TargetProperty="ScaleY" To="0" Duration="00:00:00"/>
            </Storyboard>
    
            <ControlTemplate x:Key="InnerContentButtonTemplate" TargetType="Button">
                <ContentPresenter />
            </ControlTemplate>
    
            <ControlTemplate x:Key="BackgroundButtonTemplate" TargetType="Button">
                <Grid Background="Black">
                    <Button VerticalAlignment="Center" HorizontalAlignment="Center" Click="InnerContentButtonClick" Template="{StaticResource InnerContentButtonTemplate}">
                        <ContentPresenter />
                    </Button>
                </Grid>
            </ControlTemplate>
    
            <ControlTemplate x:Key="ContentControlTemplate" TargetType="ContentControl">
                <Button x:Name="BackgroundButton" Template="{StaticResource BackgroundButtonTemplate}" Background="#B2000000" Click="BackgroundButtonClick">
                    <ContentPresenter RenderTransformOrigin="0.5, 0.5">
                        <ContentPresenter.RenderTransform>
                            <ScaleTransform x:Name="scaleTransform" ScaleX="0" ScaleY="0"/>
                        </ContentPresenter.RenderTransform>
                    </ContentPresenter>
                </Button>
            </ControlTemplate>
        </ContentControl.Resources>
    
    </ContentControl>
