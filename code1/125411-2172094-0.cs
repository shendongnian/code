    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="200"/>
            <ColumnDefinition Width="5"/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        
        <GridSplitter Grid.Column="1" VerticalAlignment="Stretch" HorizontalAlignment="Right"/>
        
        <!--TreeView Code Here-->
        <TreeView x:Name="treeView" SelectedItemChanged="TreeView_SelectedItemChanged">
            <TreeViewItem Header="Devices" IsExpanded="True">
                <TreeViewItem Header="Device 1" Tag="UserControl1.xaml"/>
                <TreeViewItem Header="Device 2" Tag="UserControl2.xaml"/>
                <TreeViewItem Header="Device 3" Tag="UserControl3.xaml"/>
            </TreeViewItem>
            <TreeViewItem Header="Users" IsExpanded="True">
                <TreeViewItem Header="Add" Tag="UserControl4.xaml"/>
                <TreeViewItem Header="Edit/Delete" Tag="UserControl5.xaml"/>
            </TreeViewItem>
        </TreeView>
        
        <!--Frame to hold your subform (UserControl)-->
        <Frame x:Name="SubForm" Grid.Column="2" NavigationUIVisibility="Hidden"/>
    </Grid>
