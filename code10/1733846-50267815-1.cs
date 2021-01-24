    <DataGrid x:Name="DgDevices"
              ItemsSource="{Binding}"
              BorderThickness="2,0,2,2"
              AutoGenerateColumns="False"
              Cursor="Cross">
        <DataGrid.ContextMenu>
            <ContextMenu >
                <MenuItem Header="Załóż Deblokadę" Click="InsertDBL"  />
                <MenuItem Header="Usuń Deblokadę" Click="RemoveDBL"/>
            </ContextMenu>
        </DataGrid.ContextMenu>
        <DataGrid.Columns> <!-- add to columns -->
            <DataGridTextColumn Binding="{Binding Name}">
                <DataGridTextColumn.ElementStyle>
                    <Style TargetType="{x:Type TextBlock}">
                        <Style.Triggers>
                            <Trigger Property="Text"
                                     Value="1">
                                <Setter Property="Background"
                                        Value="Black" />
                                <Setter Property="Foreground"
                                        Value="White" />
                            </Trigger>
                        </Style.Triggers>
                    </Style>
                </DataGridTextColumn.ElementStyle>
            </DataGridTextColumn>
        </DataGrid.Columns>
    </DataGrid>
