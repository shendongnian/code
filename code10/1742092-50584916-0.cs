    <ListView x:Name="lvConnections">
        <ListView.ItemContainerStyle>
            <Style TargetType="{x:Type ListViewItem}">
                <EventSetter Event="MouseDoubleClick" Handler="ListViewItem_MouseDoubleClick" />
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Color}" Value="Green">
                        <Setter Property="Background" Value="Green"/>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding Color}" Value="Red">
                        <Setter Property="Background" Value="Red"/>
                    </DataTrigger>
                    <DataTrigger Binding="{Binding Color}" Value="Yellow">
                        <Setter Property="Background" Value="Yellow"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition/>
                    </Grid.ColumnDefinitions>
                    <Grid.RowDefinitions>
                        <RowDefinition/>
                    </Grid.RowDefinitions>
                    <StackPanel  Width="150" MaxHeight="50" Grid.Column="0" Grid.Row="0" Orientation="Horizontal" >
                        <TextBlock VerticalAlignment="Center" Text="{Binding Name}" FontWeight="ExtraBlack" TextWrapping="Wrap" Padding="10"/>
                    </StackPanel>
                </Grid>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
