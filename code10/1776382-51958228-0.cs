    <ControlTemplate.Triggers>
        <DataTrigger Binding="{Binding HamburgerMenu_IsOpen, Mode=OneWay}" Value="True">
            <DataTrigger.EnterActions>
                <BeginStoryboard Storyboard="{StaticResource HamburgerMenuRectangles_OpenMenu}"/>
            </DataTrigger.EnterActions>
            <DataTrigger.ExitActions>
                <BeginStoryboard Storyboard="{StaticResource HamburgerMenuRectangles_CloseMenu}"/>
            </DataTrigger.ExitActions>
        </DataTrigger>
    </ControlTemplate.Triggers>
