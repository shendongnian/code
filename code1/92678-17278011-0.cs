                <GridView ColumnHeaderToolTip="Addendum Master" >
                        <GridViewColumn Width="500">
                            <GridViewColumn.CellTemplate>
                                <DataTemplate>                                    
                                    <StackPanel Orientation="Vertical" Margin="0">
                                        <Label Content="{Binding Path=Line1}" Padding="0" Margin="0" Style="{StaticResource GridLabelStyle}"></Label>
                                        <Label Content="{Binding Path=Line2}" Padding="0" Margin="0" Style="{StaticResource GridLabelStyle}"></Label>
                                        <Label Content="{Binding Path=Line3}" Padding="0" Margin="0" Style="{StaticResource GridLabelStyle}"></Label>
                                        <Label Content="{Binding Path=Line4}" Padding="0" Margin="0" Style="{StaticResource GridLabelStyle}"></Label>
                                    </StackPanel>                                                                        
                                </DataTemplate>
                            </GridViewColumn.CellTemplate>
                        </GridViewColumn>
                    </GridView.Columns>
                </GridView>
            </ListView.View>
        </ListView>
