    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Grid Grid.Row="0">
            <Grid.ColumnDefinitions>
                <ColumnDefinition></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition></RowDefinition>
            </Grid.RowDefinitions>
            <!-- i have some items control that expand horizontally for col headers here. I want it to stick to the top.-->
            <TextBlock Text="headers"></TextBlock>
        </Grid>
        <ScrollViewer Grid.Row="1" HorizontalScrollBarVisibility="Auto">
            <DockPanel LastChildFill="True">
                <ItemsControl x:Name="icContents" ItemsSource="{Binding Source={StaticResource years}}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <TextBox Text="{Binding Year}"></TextBox>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ItemsControl>
            </DockPanel>
        </ScrollViewer>
    </Grid>
