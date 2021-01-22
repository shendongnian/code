     <DataTemplate DataType="{x:Type Models:MeetingDbEntry}">
            <Grid>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="100"/>
                    <ColumnDefinition Width="100"/>
                    <ColumnDefinition Width="*"/>
                </Grid.ColumnDefinitions>
                <TextBlock Grid.Column="0"  Text="{Binding Path=HostTeam}"/>
                <TextBlock Grid.Column="1" Text="{Binding Path=GuestTeam}"/>
                <TextBlock Grid.Column="2" Text="{Binding Path=Result}"/>
                <Grid.ContextMenu>
                    <ContextMenu Name="MeetingMenu">
                        <MenuItem Header="Delete"  
                                  Command="{Binding 
                                          Source={StaticResource Locator}, 
                                          Path=Main.DeleteSelectedMeetingCommand}"
                                  CommandParameter="{Binding}"
                                  />
                                   
                    </ContextMenu>
                </Grid.ContextMenu>
            </Grid>
        </DataTemplate>
