    <ControlTemplate.Triggers>
        <MultiTrigger>
            <MultiTrigger.Conditions>
                <Condition Property="IsMouseOver" Value="True"/>
                <Condition Property="Selector.IsSelected" Value="False" />
            </MultiTrigger.Conditions>
            <MultiTrigger.EnterActions>
                <StopStoryboard BeginStoryboardName="SelectedBegin" />
                <StopStoryboard BeginStoryboardName="UnselectBegin" />
                <BeginStoryboard x:Name="EnterBegin" Storyboard="{StaticResource MouseEnterSb}"/>
            </MultiTrigger.EnterActions>
            <MultiTrigger.ExitActions>
                <BeginStoryboard x:Name="LeaveBegin" Storyboard="{StaticResource MouseLeaveSb}"/>
            </MultiTrigger.ExitActions>
        </MultiTrigger>
        <Trigger Property="Selector.IsSelected" Value="True">
            <Trigger.EnterActions>
                <StopStoryboard BeginStoryboardName="LeaveBegin" />
                <StopStoryboard BeginStoryboardName="EnterBegin" />
                <BeginStoryboard x:Name="SelectedBegin" Storyboard="{StaticResource SelectedSb}"/>
            </Trigger.EnterActions>
            <Trigger.ExitActions>
                <BeginStoryboard x:Name="UnselectBegin" Storyboard="{StaticResource UnselectSb}"/>
            </Trigger.ExitActions>
        </Trigger>
    </ControlTemplate.Triggers> 
