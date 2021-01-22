        <ItemsControl x:Name="myItems">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition />
                            <ColumnDefinition />
                            <ColumnDefinition />
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition />
                            <RowDefinition />
                            <RowDefinition />
                        </Grid.RowDefinitions>
                    </Grid>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
            <ItemsControl.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding MyText}" />
                </DataTemplate>
            </ItemsControl.ItemTemplate>
            <ItemsControl.ItemContainerStyle>
                <Style>
                    <Style.Setters>
                        <Setter Property="Grid.Row" Value="{Binding MyRow}" />
                        <Setter Property="Grid.Column" Value="{Binding MyColumn}" />
                    </Style.Setters>
                </Style>
            </ItemsControl.ItemContainerStyle>
        </ItemsControl>
