     <StackPanel Grid.Row="0" Height="175" Orientation="Vertical" Width="Auto">
                                    
     <StackPanel.Triggers>
    <EventTrigger RoutedEvent="StackPanel.Loaded">
    <EventTrigger.Actions>
    <BeginStoryboard>
    <Storyboard x:Name="mystoryboard">
    <DoubleAnimationUsingKeyFrames
    Storyboard.TargetName="Trans" 
    Storyboard.TargetProperty="X">
    <LinearDoubleKeyFrame Value="-387" KeyTime="0:0:1" />
    </DoubleAnimationUsingKeyFrames>
    </Storyboard>
                                                    
                                                </BeginStoryboard>
                                            </EventTrigger.Actions>
                                        </EventTrigger>
                                    </StackPanel.Triggers>
    <TextBlock Margin="400,40,-400,0" TextWrapping="Wrap" Text="{Binding ApplicationName}"      FontSize="21.333">
               <TextBlock.RenderTransform>
               <TranslateTransform x:Name="Trans" X="0" Y="0" />
               </TextBlock.RenderTransform>
               </TextBlock>
