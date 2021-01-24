    <Expander Grid.Column="0" ExpandDirection="Right" Width="auto" IsExpanded="false" Header="Options" Background="#ececec" Padding="5">
        <StackPanel>
                
            <Label Content="Columns:" FontWeight="SemiBold" />
            <ItemsControl ItemsSource="{Binding ElementName=DataGridName, Path=Columns}" Grid.IsSharedSizeScope="True" Margin="5">
                <ItemsControl.ItemsPanel>
                    <ItemsPanelTemplate>
                        <StackPanel Orientation="Vertical" />
                    </ItemsPanelTemplate>
                </ItemsControl.ItemsPanel>
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <Grid>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition SharedSizeGroup="A"/>
                                <ColumnDefinition SharedSizeGroup="B"/>
                            </Grid.ColumnDefinitions>
                            <TextBlock Text="{Binding Header}" Margin="20, 5, 5, 0"/>
                            <CheckBox Grid.Column="1"  IsChecked="{Binding Visibility, Converter=cnv:CustomVisibilityToBool CollapsedValue=False, VisibleValue=True}}"
                                      Margin="5" HorizontalAlignment="Center" VerticalAlignment="Center"/>
                        </Grid>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
        </StackPanel>
    </Expander>
