    <!-- needs the SilverlightToolkit for WrapPanel -->
    <!-- xmlns:tk="clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Toolkit" -->
    <ListBox ItemsSource="{Binding}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <Grid Width="400">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="*"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Grid.Column="0" Text="{Binding UserName}"/>
                    <ListBox 
                        Grid.Column="1" 
                        ItemsSource="{Binding FlickrPhotos}"
                        ScrollViewer.HorizontalScrollBarVisibility="Disabled">
                        <ListBox.ItemsPanel>
                            <ItemsPanelTemplate>
                                <tk:WrapPanel/>
                            </ItemsPanelTemplate>
                        </ListBox.ItemsPanel>
                        <ListBox.ItemTemplate>
                            <DataTemplate>
                                <Image Source="{Binding Photo}" Width="80"/>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>
                </Grid>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
