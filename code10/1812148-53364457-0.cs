    <DataGrid Grid.Column="2" 
              Grid.Row="1" Grid.RowSpan="2"
              Height="100"
              x:Name="assetListGrid"
                      HorizontalAlignment="Stretch"
                      VerticalAlignment="Top"
                      Margin="10 10 20 20" 
                      BorderThickness="1"
                             VerticalScrollBarVisibility="Auto"
                      AutoGenerateColumns="False"
                      ItemsSource="{Binding AssetList, Mode=TwoWay}" 
                      >
        <DataGrid.Resources>
            <Style x:Key="DataGridColumnHeader" TargetType="{x:Type DataGridColumnHeader}">
                <Setter Property="VerticalContentAlignment" Value="Center" />
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type DataGridColumnHeader}">
                            <Grid >
                                <ContentPresenter SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"
                                  VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                  HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" />
                            </Grid>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGrid.Resources>
        <DataGrid.Columns>
            <DataGridTextColumn  Header="Asset" 
                                        HeaderStyle="{StaticResource DataGridColumnHeader}">
                <DataGridTextColumn.HeaderTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Vertical">
                            <TextBlock/>
                            <DataGridColumnHeader Content="Asset Number"/>
                        </StackPanel>
                    </DataTemplate>
                </DataGridTextColumn.HeaderTemplate>
            </DataGridTextColumn>
            <DataGridTextColumn Header="Name" 
                                         HeaderStyle="{StaticResource DataGridColumnHeader}">
                <DataGridTextColumn.HeaderTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Vertical">
                            <TextBlock Text="Asset"/>
                            <DataGridColumnHeader  Content="Name"  />
                        </StackPanel>
                    </DataTemplate>
                </DataGridTextColumn.HeaderTemplate>
            </DataGridTextColumn>
            <DataGridTextColumn 
                                         HeaderStyle="{StaticResource DataGridColumnHeader}">
                <DataGridTextColumn.HeaderTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Vertical">
                            <TextBlock />
                            <DataGridColumnHeader Content="Role" />
                        </StackPanel>
                    </DataTemplate>
                </DataGridTextColumn.HeaderTemplate>
            </DataGridTextColumn>
            <DataGridTextColumn 
                                         HeaderStyle="{StaticResource DataGridColumnHeader}">
                <DataGridTextColumn.HeaderTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Vertical">
                            <TextBlock />
                            <DataGridColumnHeader Content="Comment" />
                        </StackPanel>
                    </DataTemplate>
                </DataGridTextColumn.HeaderTemplate>
            </DataGridTextColumn>
            <DataGridTextColumn 
                                         HeaderStyle="{StaticResource DataGridColumnHeader}">
                <DataGridTextColumn.HeaderTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Vertical">
                            <TextBlock />
                            <DataGridColumnHeader Content="Creation TimeStamp" />
                        </StackPanel>
                    </DataTemplate>
                </DataGridTextColumn.HeaderTemplate>
            </DataGridTextColumn>
            <DataGridTextColumn  Header="Asset" 
                                        HeaderStyle="{StaticResource DataGridColumnHeader}">
                <DataGridTextColumn.HeaderTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Vertical">
                            <TextBlock/>
                            <DataGridColumnHeader Content="Asset Number"/>
                        </StackPanel>
                    </DataTemplate>
                </DataGridTextColumn.HeaderTemplate>
            </DataGridTextColumn>
            <DataGridTextColumn Header="Name" 
                                         HeaderStyle="{StaticResource DataGridColumnHeader}">
                <DataGridTextColumn.HeaderTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Vertical">
                            <TextBlock Text="Manufacturer "/>
                            <DataGridColumnHeader  Content="Name"  />
                        </StackPanel>
                    </DataTemplate>
                </DataGridTextColumn.HeaderTemplate>
            </DataGridTextColumn>
            <DataGridTextColumn 
                                         HeaderStyle="{StaticResource DataGridColumnHeader}">
                <DataGridTextColumn.HeaderTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Vertical">
                            <TextBlock />
                            <DataGridColumnHeader Content="Role" />
                        </StackPanel>
                    </DataTemplate>
                </DataGridTextColumn.HeaderTemplate>
            </DataGridTextColumn>
            <DataGridTextColumn 
                                         HeaderStyle="{StaticResource DataGridColumnHeader}">
                <DataGridTextColumn.HeaderTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Vertical">
                            <TextBlock />
                            <DataGridColumnHeader Content="Comment" />
                        </StackPanel>
                    </DataTemplate>
                </DataGridTextColumn.HeaderTemplate>
            </DataGridTextColumn>
            <DataGridTextColumn 
                                         HeaderStyle="{StaticResource DataGridColumnHeader}">
                <DataGridTextColumn.HeaderTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Vertical">
                            <TextBlock />
                            <DataGridColumnHeader Content="Creation TimeStamp" />
                        </StackPanel>
                    </DataTemplate>
                </DataGridTextColumn.HeaderTemplate>
            </DataGridTextColumn>
        </DataGrid.Columns>
        <DataGridTextColumn 
                                         HeaderStyle="{StaticResource DataGridColumnHeader}">
            <DataGridTextColumn.HeaderTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Vertical">
                        <TextBlock />
                        <DataGridColumnHeader Content="Location" />
                    </StackPanel>
                </DataTemplate>
            </DataGridTextColumn.HeaderTemplate>
        </DataGridTextColumn>
        <DataGridTextColumn 
                                         HeaderStyle="{StaticResource DataGridColumnHeader}">
            <DataGridTextColumn.HeaderTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Vertical">
                        <TextBlock />
                        <DataGridColumnHeader Content="Value" />
                    </StackPanel>
                </DataTemplate>
            </DataGridTextColumn.HeaderTemplate>
        </DataGridTextColumn>
    </DataGrid>
