    <Style x:Key="TextBoxStyle1" TargetType="TextBox">
       <Setter Property="BorderThickness" Value="1"/>
       <Setter Property="Background" Value="#FFFFFFFF"/>
       <Setter Property="Foreground" Value="#FF000000"/>
       <Setter Property="Padding" Value="2"/>
       <Setter Property="BorderBrush">
        <Setter.Value>
         <LinearGradientBrush EndPoint="0.5,1" StartPoint="0.5,0">
          <GradientStop Color="#FFA3AEB9" Offset="0"/>
          <GradientStop Color="#FF8399A9" Offset="0.375"/>
          <GradientStop Color="#FF718597" Offset="0.375"/>
          <GradientStop Color="#FF617584" Offset="1"/>
         </LinearGradientBrush>
        </Setter.Value>
       </Setter>
       <Setter Property="Template">
        <Setter.Value>
         <ControlTemplate TargetType="TextBox">
          <Grid x:Name="RootElement">
           <VisualStateManager.VisualStateGroups>
            <VisualStateGroup x:Name="CommonStates">
             <VisualState x:Name="Normal"/>
             <VisualState x:Name="MouseOver">
    
             </VisualState>
             <VisualState x:Name="Disabled">
              <Storyboard>
               <DoubleAnimation Duration="0" To="1" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="DisabledVisualElement"/>
              </Storyboard>
             </VisualState>
             <VisualState x:Name="ReadOnly">
              <Storyboard>
               <DoubleAnimation Duration="0" To="1" Storyboard.TargetProperty="Opacity" Storyboard.TargetName="ReadOnlyVisualElement"/>
              </Storyboard>
             </VisualState>
            </VisualStateGroup>
            <VisualStateGroup x:Name="FocusStates">
             <VisualState x:Name="Focused">          
             </VisualState>
             <VisualState x:Name="Unfocused">
             </VisualState>
            </VisualStateGroup>
            <VisualStateGroup x:Name="ValidationStates">
             <VisualState x:Name="Valid"/>
             <VisualState x:Name="InvalidUnfocused">
              <Storyboard>
               <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="ValidationErrorElement">
                <DiscreteObjectKeyFrame KeyTime="0">
                 <DiscreteObjectKeyFrame.Value>
                  <Visibility>Visible</Visibility>
                 </DiscreteObjectKeyFrame.Value>
                </DiscreteObjectKeyFrame>
               </ObjectAnimationUsingKeyFrames>
              </Storyboard>
             </VisualState>
             <VisualState x:Name="InvalidFocused">
              <Storyboard>
               <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="Visibility" Storyboard.TargetName="ValidationErrorElement">
                <DiscreteObjectKeyFrame KeyTime="0">
                 <DiscreteObjectKeyFrame.Value>
                  <Visibility>Visible</Visibility>
                 </DiscreteObjectKeyFrame.Value>
                </DiscreteObjectKeyFrame>
               </ObjectAnimationUsingKeyFrames>
               <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="IsOpen" Storyboard.TargetName="validationTooltip">
                <DiscreteObjectKeyFrame KeyTime="0">
                 <DiscreteObjectKeyFrame.Value>
                  <System:Boolean>True</System:Boolean>
                 </DiscreteObjectKeyFrame.Value>
                </DiscreteObjectKeyFrame>
               </ObjectAnimationUsingKeyFrames>
              </Storyboard>
             </VisualState>
            </VisualStateGroup>
           </VisualStateManager.VisualStateGroups>
           
            <Grid>
             <Border x:Name="ReadOnlyVisualElement" Background="#5EC9C9C9" Opacity="0"/>
             <Border x:Name="MouseOverBorder" BorderBrush="Transparent" BorderThickness="1">
              <ScrollViewer x:Name="ContentElement" BorderThickness="0" IsTabStop="False" Padding="{TemplateBinding Padding}"/>
             </Border>
            </Grid>
        
           <Border x:Name="DisabledVisualElement" BorderBrush="#A5F7F7F7" BorderThickness="{TemplateBinding BorderThickness}" Background="#A5F7F7F7" IsHitTestVisible="False" Opacity="0"/>       
           <Border x:Name="ValidationErrorElement" BorderBrush="#FFDB000C" BorderThickness="1" CornerRadius="1" Visibility="Collapsed">
            <ToolTipService.ToolTip>
             <ToolTip x:Name="validationTooltip" DataContext="{Binding RelativeSource={RelativeSource TemplatedParent}}" Placement="Right" PlacementTarget="{Binding RelativeSource={RelativeSource TemplatedParent}}" >
              <ToolTip.Triggers>
               <EventTrigger RoutedEvent="Canvas.Loaded">
                <BeginStoryboard>
                 <Storyboard>
                  <ObjectAnimationUsingKeyFrames Storyboard.TargetProperty="IsHitTestVisible" Storyboard.TargetName="validationTooltip">
                   <DiscreteObjectKeyFrame KeyTime="0">
                    <DiscreteObjectKeyFrame.Value>
                     <System:Boolean>true</System:Boolean>
                    </DiscreteObjectKeyFrame.Value>
                   </DiscreteObjectKeyFrame>
                  </ObjectAnimationUsingKeyFrames>
                 </Storyboard>
                </BeginStoryboard>
               </EventTrigger>
              </ToolTip.Triggers>
             </ToolTip>
            </ToolTipService.ToolTip>
            <Grid Background="Transparent" HorizontalAlignment="Right" Height="12" Margin="1,-4,-4,0" VerticalAlignment="Top" Width="12">
             <Path Data="M 1,0 L6,0 A 2,2 90 0 1 8,2 L8,7 z" Fill="#FFDC000C" Margin="1,3,0,0"/>
             <Path Data="M 0,0 L2,0 L 8,6 L8,8" Fill="#ffffff" Margin="1,3,0,0"/>
            </Grid>
           </Border>
          </Grid>
         </ControlTemplate>
        </Setter.Value>
       </Setter>
      </Style>
