    <ListView Name="MyListview">
        <ListView.ItemTemplate>
            <DataTemplate>
                <StackPanel Orientation="Horizontal">
                    <CheckBox Content="Can fly">
                        <CheckBox.Style>
                            <Style TargetType="CheckBox">
                                <Setter Property="Visibility" Value="Collapsed"/>
                                <Style.Triggers>
                                    <DataTrigger Binding="{Binding IsBird}" Value="True">
                                        <Setter Property="Visibility" Value="Visible"/>
                                    </DataTrigger>
                                </Style.Triggers>
                            </Style>
                        </CheckBox.Style>
                    </CheckBox>
                    <TextBlock Text="Anything"/>
                </StackPanel>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
