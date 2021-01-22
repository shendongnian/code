    <Grid>
        <ListView ItemsSource="{Binding ListViewSource}">
            <ListView.View>
                <GridView>
                    <GridViewColumn Width="25">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate>
                                <Image Source="{Binding Icon}"/>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                    <GridViewColumn Header="Name" DisplayMemberBinding="{Binding FileName}" Width="250"/>
                    <GridViewColumn Header="Date Modified" DisplayMemberBinding="{Binding DateModified}" Width="100"/>
                    <GridViewColumn Header="Type" DisplayMemberBinding="{Binding FileType}" Width="100"/>
                    <GridViewColumn Header="Size" DisplayMemberBinding="{Binding FileSize}" Width="100"/>
                </GridView>
            </ListView.View>
        </ListView>
    </Grid>
