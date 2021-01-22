       <ListView.Resources>
        <ContextMenu x:Key="ItemContextMenu">
            <MenuItem x:Name="menuItem_CopyUsername"
                      Click="menuItem_CopyUsername_Click"
                      Header="Copy Username">
                <MenuItem.Icon>
                    <Image Source="/mypgm;component/Images/Copy.png" />
                </MenuItem.Icon>
            </MenuItem>
            <MenuItem x:Name="menuItem_CopyPassword"
                      Click="menuItem_CopyPassword_Click"
                      Header="Copy Password">
                <MenuItem.Icon>
                    <Image Source="/mypgm;component/Images/addclip.png" />
                </MenuItem.Icon>
            </MenuItem>
            <Separator />
            <MenuItem x:Name="menuItem_DeleteCreds"
                      Click="menuItem_DeleteCreds_Click"
                      Header="Delete">
                <MenuItem.Icon>
                    <Image Source="/mypgm;component/Images/Delete.png" />
                </MenuItem.Icon>
            </MenuItem>
        </ContextMenu>
    </ListView.Resources>
    <ListView.ItemContainerStyle>
        <Style TargetType="{x:Type ListViewItem}">
            <Setter Property="ContextMenu" Value="{StaticResource ItemContextMenu}" />
        </Style>
    </ListView.ItemContainerStyle>
