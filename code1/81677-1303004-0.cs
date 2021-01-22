    <Style TargetType="{x:Type Button}">
      <Setter Property="Template">
        <Setter.Value>
          <ControlTemplate TargetType="{x:Type Button}">
            <Border>
              <ContentPresenter HorizontalAlignment="Center"
                                VerticalAlignment="Center"/>
              <Border.ContextMenu>
                <ContextMenu Name="contextMenu">
                  <MenuItem Header="Here's a menu."/>
                </ContextMenu>
              </Border.ContextMenu>
            </Border>
          </ControlTemplate>
        </Setter.Value>
      </Setter>
    </Style>
