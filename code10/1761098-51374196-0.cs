            <ItemsControl x:Name="mainPanel" Grid.Column="0" ItemsSource="{Binding}">
                <ItemsControl.ItemsPanel>
                    <ItemsPanelTemplate>
                        <WrapPanel Background="#F0F0F0"  AllowDrop="True"  Drop="mainPanel_Drop">
                            <WrapPanel.ContextMenu>
                                <ContextMenu>
                                    <MenuItem Click="MenuItem_Click" Header="Add Panel" />
                                </ContextMenu>
                            </WrapPanel.ContextMenu>
                        </WrapPanel>
                    </ItemsPanelTemplate>
                </ItemsControl.ItemsPanel>
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Vertical" Background="White"  AllowDrop="True" Margin="15,15,0,10" Width="150" MinWidth="150" Height="150" MinHeight="150">
                            <Label Content="{Binding Name}"/>
                            <Label Content="{Binding ID}"/>
                            <Label Content="{Binding Address}"/>
                        </StackPanel>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
