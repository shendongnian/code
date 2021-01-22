    <ListView.View>
        <GridView>
            <GridViewColumn Header="Date" Width="Auto" DisplayMemberBinding="{Binding Date}" />
            <GridViewColumn Header="Time" Width="Auto" DisplayMemberBinding="{Binding Time}" />
            <GridViewColumn Header="FriendlyName" Width="Auto" DisplayMemberBinding="{Binding FriendlyName}" />
            <GridViewColumn Width="Auto">
                <GridViewColumn.CellTemplate>
                  <DataTemplate>
                         <Image Source="Resources\saveicon.png"></Image>
                  </DataTemplate>
                </GridViewColumn.CellTemplate>
            </GridViewColumn>
        </GridView>
    </ListView.View>
