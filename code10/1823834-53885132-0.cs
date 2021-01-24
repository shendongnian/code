    <Style x:Key="BlinkingAnimationStyle" TargetType="{x:Type TextBlock}">
        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.ControlTextBrushKey}}"/>
        <Setter Property="Background" Value="Transparent"/>
        <Style.Triggers>
            <DataTrigger Binding="{Binding Path=BlinkOn}" Value="true">
                <DataTrigger.EnterActions>
                    <BeginStoryboard x:Name="BlinkingAnimation_BeginStoryboard" Storyboard="{StaticResource BlinkingAnimation}" />
                </DataTrigger.EnterActions>
                <DataTrigger.ExitActions>
                    <RemoveStoryboard BeginStoryboardName="BlinkingAnimation_BeginStoryboard" />
                </DataTrigger.ExitActions>
            </DataTrigger>
            <DataTrigger Binding="{Binding Path=BlinkOn}" Value="false">
                <DataTrigger.EnterActions>
                    <RemoveStoryboard BeginStoryboardName="BlinkingAnimation_BeginStoryboard" />
                </DataTrigger.EnterActions>
            </DataTrigger>
        </Style.Triggers>
    </Style>
