      <Style TargetType="avalonDockControls:AnchorablePaneTitle">
        <Setter Property="Template">
          <Setter.Value>
            <ControlTemplate>
              <Border Background="{TemplateBinding Background}"
                      BorderBrush="{TemplateBinding BorderBrush}"
                      BorderThickness="{TemplateBinding BorderThickness}">
                <Grid>
                  <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*" />
                    <ColumnDefinition Width="Auto" />
                    <ColumnDefinition Width="Auto" />
                    <ColumnDefinition Width="Auto" />
                  </Grid.ColumnDefinitions>
                  <avalonDockControls:DropDownControlArea DropDownContextMenu="{Binding Model.Root.Manager.AnchorableContextMenu, RelativeSource={RelativeSource TemplatedParent}}"
                                                          DropDownContextMenuDataContext="{Binding Path=LayoutItem, RelativeSource={RelativeSource TemplatedParent}}">
                    <ContentPresenter Content="{Binding Model, RelativeSource={RelativeSource TemplatedParent}}"
                                      ContentTemplate="{Binding Model.Root.Manager.AnchorableTitleTemplate, RelativeSource={RelativeSource TemplatedParent}}"
                                      ContentTemplateSelector="{Binding Model.Root.Manager.AnchorableTitleTemplateSelector, RelativeSource={RelativeSource TemplatedParent}}" />
                  </avalonDockControls:DropDownControlArea>
    
                  <avalonDockControls:DropDownButton Style="{StaticResource {x:Static ToolBar.ToggleButtonStyleKey}}"
                                                     Focusable="False"
                                                     Grid.Column="1"
                                                     DropDownContextMenu="{Binding Model.Root.Manager.AnchorableContextMenu, RelativeSource={RelativeSource TemplatedParent}}"
                                                     DropDownContextMenuDataContext="{Binding Path=LayoutItem, RelativeSource={RelativeSource TemplatedParent}}"
                                                     ToolTip="{x:Static avalonDockProperties:Resources.Anchorable_CxMenu_Hint}">
                    <Border Background="White">
                      <Image Source="/Xceed.Wpf.AvalonDock;component/Themes/Generic/Images/PinMenu.png">
                      </Image>
                    </Border>
                  </avalonDockControls:DropDownButton>
    
                  <Button x:Name="PART_AutoHidePin"
                          Grid.Column="2"
                          Focusable="False"
                          Style="{StaticResource {x:Static ToolBar.ButtonStyleKey}}"
                          Visibility="{Binding Path=IsEnabled, RelativeSource={RelativeSource Self}, Mode=OneWay, Converter={StaticResource BoolToVisibilityConverter}}"
                          Command="{Binding Path=LayoutItem.AutoHideCommand, RelativeSource={RelativeSource TemplatedParent}}"
                          ToolTip="{x:Static avalonDockProperties:Resources.Anchorable_BtnAutoHide_Hint}">
                    <Border Background="White">
                      <Image Source="/Xceed.Wpf.AvalonDock;component/Themes/Generic/Images/PinAutoHide.png">
                      </Image>
                    </Border>
                  </Button>
    
                  <Button x:Name="PART_HidePin"
                          Grid.Column="3"
                          Focusable="False"
                          Style="{StaticResource {x:Static ToolBar.ButtonStyleKey}}"
                          Visibility="{Binding Path=IsEnabled, RelativeSource={RelativeSource Self}, Mode=OneWay, Converter={StaticResource BoolToVisibilityConverter}}"
                          Command="{Binding Path=LayoutItem.HideCommand, RelativeSource={RelativeSource TemplatedParent}}"
                          ToolTip="{x:Static avalonDockProperties:Resources.Anchorable_BtnClose_Hint}">
                    <Border Background="White">
                      <Image Source="/Xceed.Wpf.AvalonDock;component/Themes/Generic/Images/PinClose.png">
                      </Image>
                    </Border>
                  </Button>
    
    
                </Grid>
              </Border>
              <ControlTemplate.Triggers>
                <DataTrigger Binding="{Binding Model.IsAutoHidden, RelativeSource={RelativeSource Mode=Self}}"
                             Value="True">
                  <Setter Property="LayoutTransform"
                          TargetName="PART_AutoHidePin">
                    <Setter.Value>
                      <RotateTransform Angle="90" />
                    </Setter.Value>
                  </Setter>
                </DataTrigger>
                <DataTrigger Binding="{Binding Model.CanClose, RelativeSource={RelativeSource Mode=Self}}"
                             Value="True">
                  <Setter Property="Command"
                          TargetName="PART_HidePin"
                          Value="{Binding Path=LayoutItem.CloseCommand, RelativeSource={RelativeSource TemplatedParent}}" />
                  <Setter Property="ToolTip"
                          TargetName="PART_HidePin"
                          Value="{x:Static avalonDockProperties:Resources.Document_Close}" />
    
                </DataTrigger>
              </ControlTemplate.Triggers>
            </ControlTemplate>
          </Setter.Value>
        </Setter>
      </Style>
