    <Style x:Key="ScrollViewerTextBox" TargetType="{x:Type ScrollViewer}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type ScrollViewer}">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition/>
                            <ColumnDefinition Width="Auto" MinWidth="18"/>
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition/>
                            <RowDefinition Height="Auto"/>
                        </Grid.RowDefinitions>
                        <ScrollContentPresenter Grid.Column="0" Margin="3 3 3 0" CanVerticallyScroll="True" CanContentScroll="True"/>
                        <ScrollBar x:Name="PART_VerticalScrollBar" 
                                   Grid.Row="0" 
                                   Grid.Column="1"
                                   Value="{TemplateBinding VerticalOffset}" 
                                   Maximum="{TemplateBinding ScrollableHeight}" 
                                   ViewportSize="{TemplateBinding ViewportHeight}" 
                                   Visibility="{TemplateBinding ComputedVerticalScrollBarVisibility}">
                            <ScrollBar.ContextMenu>
                                <ContextMenu Visibility="Hidden" />
                            </ScrollBar.ContextMenu>
                        </ScrollBar>
                        <ScrollBar x:Name="PART_HorizontalScrollBar" 
                                   Orientation="Horizontal" 
                                   Grid.Row="1" 
                                   Grid.Column="0" 
                                   Value="{TemplateBinding HorizontalOffset}" 
                                   Maximum="{TemplateBinding ScrollableWidth}" 
                                   ViewportSize="{TemplateBinding ViewportWidth}" 
                                   Visibility="{TemplateBinding ComputedHorizontalScrollBarVisibility}">
                            <ScrollBar.ContextMenu>
                                <ContextMenu Visibility="Hidden" />
                            </ScrollBar.ContextMenu>
                        </ScrollBar>
                    </Grid>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
