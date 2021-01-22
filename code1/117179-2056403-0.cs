    <ListView x:Name="ListView1" Background="#FFEEF3FA" SelectionChanged="ListView1_SelectionChanged" VirtualizingStackPanel.IsVirtualizing="True" local:ListViewSorter.IsListviewSortable="True" MouseDoubleClick="ListView1_MouseDoubleClick" ItemsSource="{Binding ListViewItemsCollections}">
        <ListView.View>
            <GridView AllowsColumnReorder="False">
                <GridViewColumn x:Name="GridViewColumnName" Header="Name"  Width="200">
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <Image x:Name="Image_GridViewColumnName" Width="16" Height="16" Source="{Binding GridViewColumnName_ImageSource}" />
                                <Label Content="{Binding GridViewColumnName_LabelContent}" />
                                <Label Content="{Binding GridViewColumnName_ID}" Visibility="Hidden" />
                            </StackPanel>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
                <GridViewColumn x:Name="GridViewColumnTags" Header="Tags" Width="100" DisplayMemberBinding="{Binding GridViewColumnTags}" />
                <GridViewColumn x:Name="GridViewColumnLocation" Header="Location" Width="238" DisplayMemberBinding="{Binding GridViewColumnLocation}" />
            </GridView>
        </ListView.View>
