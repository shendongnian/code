    <Style x:Key="perTreeViewItemContainerStyle"
           TargetType="{x:Type TreeViewItem}">
        <!-- Link the properties of perTreeViewItemViewModelBase to the corresponding ones on the TreeViewItem -->
        <Setter Property="IsExpanded" Value="{Binding IsExpanded, Mode=TwoWay}" />
        <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}" />
        <Setter Property="IsEnabled" Value="{Binding IsEnabled}" />
        
        <!-- Include the two "Scroll into View" behaviors -->
        <Setter Property="vhelp:perTreeViewItemHelper.BringSelectedItemIntoView" Value="True" />
        <Setter Property="vhelp:perTreeViewItemHelper.BringExpandedChildrenIntoView" Value="True" />
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type TreeViewItem}">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto"
                                              MinWidth="14" />
                            <ColumnDefinition Width="*" />
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="*" />
                        </Grid.RowDefinitions>
                        <ToggleButton x:Name="Expander"
                                      Grid.Row="0"
                                      Grid.Column="0"
                                      ClickMode="Press"
                                      IsChecked="{Binding Path=IsExpanded, RelativeSource={RelativeSource TemplatedParent}}"
                                      Style="{StaticResource perExpandCollapseToggleStyle}" />
                        <Border x:Name="PART_Border"
                                Grid.Row="0"
                                Grid.Column="1"
                                Padding="{TemplateBinding Padding}"
                                Background="{TemplateBinding Background}"
                                BorderBrush="{TemplateBinding BorderBrush}"
                                BorderThickness="{TemplateBinding BorderThickness}">
                            <ContentPresenter x:Name="PART_Header"
                                              Margin="0,2"
                                              HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                              ContentSource="Header" />
                        </Border>
                        <ItemsPresenter x:Name="ItemsHost"
                                        Grid.Row="1"
                                        Grid.Column="1" />
                    </Grid>
                    <ControlTemplate.Triggers>
                        <Trigger Property="IsExpanded" Value="false">
                            <Setter TargetName="ItemsHost" Property="Visibility" Value="Collapsed" />
                        </Trigger>
                        <Trigger Property="HasItems" Value="false">
                            <Setter TargetName="Expander" Property="Visibility" Value="Hidden" />
                        </Trigger>
                        <!--  Use the same colors for a selected item, whether the TreeView is focussed or not  -->
                        <Trigger Property="IsSelected" Value="true">
                            <Setter TargetName="PART_Border" Property="Background" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}" />
                            <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.HighlightTextBrushKey}}" />
                        </Trigger>
                        <Trigger Property="IsEnabled" Value="false">
                            <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}" />
                        </Trigger>
                    </ControlTemplate.Triggers>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
    <Style TargetType="{x:Type TreeView}">
        <Setter Property="ItemContainerStyle" Value="{StaticResource perTreeViewItemContainerStyle}" />
    </Style>
