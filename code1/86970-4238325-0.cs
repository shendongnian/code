    <ListView.ContextMenu>
        <ContextMenu ItemsSource="{Binding Path=VMMenuItems}">
               <ContextMenu.ItemContainerStyle>
                    <Style TargetType="{x:Type MenuItem}">                                    
                            <Setter Property="Command" Value="{Binding Command}"/>
                      </Style>
                </ContextMenu.ItemContainerStyle>
          </ContextMenu>                    
    </ListView.ContextMenu>
