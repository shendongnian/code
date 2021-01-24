    <TextBox Text="{Binding TextBoxOne, UpdateSourceTrigger=LostFocus}">
        <TextBox.ContextMenu>
            <ContextMenu>
                <ContextMenu.Resources>
                    <local:CompositeParameter x:Key="paramA"
                                              Value="35" 
                                              Control="{Binding PlacementTarget, RelativeSource={RelativeSource AncestorType=ContextMenu}}" />
                    <local:CompositeParameter x:Key="paramB"
                                              Value="50" 
                                              Control="{Binding PlacementTarget, RelativeSource={RelativeSource AncestorType=ContextMenu}}" />
                </ContextMenu.Resources>
                <MenuItem Header="Set to 35"
                          Command="{Binding SetAmountCommand}" 
                          CommandParameter="{StaticResource paramA}" />
                <MenuItem Header="Set to 50"
                          Command="{Binding SetAmountCommand}"
                          CommandParameter="{StaticResource paramB}" />
            </ContextMenu>
        </TextBox.ContextMenu>
    </TextBox>
