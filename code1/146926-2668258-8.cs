    <ControlTemplate ...>
      <ControlTemplate.Resources>
        <ContextMenu x:Key="NormalMenu">
          ...
        </ContextMenu>
        <ContextMenu x:Key="AlternateMenu">
          ...
        </ContextMenu>
      </ControlTemplate.Resources>
      ...
      <ListBox x:Name="MyList" ContextMenu="{StaticResource NormalMenu}">
      ...
      <ControlTemplate.Triggers>
        <Trigger Property="IsSpecialSomethingOrOther" Value="True">
          <Setter TargetName="MyList" Property="ContextMenu" Value="{StaticResource AlternateMenu}" />
        </Trigger>
      </ControlTemplate.Triggers>
    </ControlTemplate>
