    <GroupBox>
        <StackPanel Orientation="Vertical">
            <DataGrid x:Name="Dt" Visibility="Collapsed">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="home" />
                </DataGrid.Columns>
            </DataGrid>
            <Label Content="Foo">
                <Label.Style>
                    <Style TargetType="Label">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding Visibility, ElementName=Dt}" Value="Visible">
                                <Setter Property="Visibility" Value="Collapsed" />
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </Label.Style>
            </Label>
        </StackPanel>
    </GroupBox>
