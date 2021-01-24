    <Grid>
        <DockPanel LastChildFill="True">
            <Grid DockPanel.Dock="Top">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition></ColumnDefinition>
                </Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                    <RowDefinition></RowDefinition>
                </Grid.RowDefinitions>
                <!-- i have some items control that expand horizontally for col headers here. I want it to stick to the top.-->
                <TextBlock Text="headers"></TextBlock>
            </Grid>
            <ScrollViewer HorizontalScrollBarVisibility="Auto">
                <ItemsControl x:Name="icContents" ItemsSource="{Binding Source={StaticResource years}}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <TextBox Text="{Binding Year}"></TextBox>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </ScrollViewer>
        </DockPanel>
    </Grid>
