    <Style x:Key="{x:Type TreeViewItem}" TargetType="{x:Type TreeViewItem}">
                    <Setter Property="Background" Value="Transparent"/>
                    <Setter Property="HorizontalContentAlignment" Value="{Binding HorizontalContentAlignment, RelativeSource={RelativeSource AncestorType={x:Type ItemsControl}}}"/>
                    <Setter Property="VerticalContentAlignment" Value="{Binding VerticalContentAlignment, RelativeSource={RelativeSource AncestorType={x:Type ItemsControl}}}"/>
                    <Setter Property="Padding" Value="1,0,0,0"/>
                    <Setter Property="Foreground" Value="Black"/>
                    <Setter Property="FocusVisualStyle" Value="{StaticResource TreeViewItemFocusVisual}"/>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type TreeViewItem}">
                                <StackPanel>
                                    <Border x:Name="Bd" Grid.ColumnSpan="3" BorderThickness="1" Padding="{TemplateBinding Padding}" SnapsToDevicePixels="true" Margin="3,0,3,-1" MinHeight="20">
                                        <Border.Style>
                                            <Style TargetType="{x:Type Border}">
                                                <Style.Triggers>
                                                    <Trigger Property="IsMouseOver" Value="true">
                                                        <Setter Property="Background" Value="Red"/>
                                                        <Setter Property="BorderBrush" Value="Black"/>
                                                    </Trigger>
                                                    <Trigger Property="IsMouseOver" Value="false">
                                                        <Setter Property="Background" Value="Transparent"/>
                                                    </Trigger>
                                                </Style.Triggers>
                                            </Style>
                                        </Border.Style>
                                        <Grid>
                                            <Grid.ColumnDefinitions>
                                                <ColumnDefinition MinWidth="19" Width="Auto"/>
                                                <ColumnDefinition Width="Auto"/>
                                            </Grid.ColumnDefinitions>
                                            <ToggleButton x:Name="Expander" ClickMode="Press" IsChecked="{Binding IsExpanded, RelativeSource={RelativeSource TemplatedParent}}" Style="{StaticResource ExpandCollapseToggleStyle}"/>
                                            <ContentPresenter x:Name="PART_Header" ContentSource="Header" Grid.Column="1" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                                        </Grid>
                                    </Border>
        
                                    <ItemsPresenter x:Name="ItemsHost" Grid.ColumnSpan="2" Grid.Column="1" Grid.Row="1"/>
                                </StackPanel>
                                <ControlTemplate.Triggers>
                                    <Trigger Property="IsExpanded" Value="false">
                                        <Setter Property="Visibility" TargetName="ItemsHost" Value="Collapsed"/>
                                    </Trigger>
                                    <Trigger Property="HasItems" Value="false">
                                        <Setter Property="Visibility" TargetName="Expander" Value="Hidden"/>
                                    </Trigger>
                                    <Trigger Property="IsSelected" Value="true">
                                        <Setter Property="Background" TargetName="Bd" Value="Green"/>
                                        <Setter Property="BorderBrush" TargetName="Bd" Value="Black"/>
                                    </Trigger>
                                    <MultiTrigger>
                                        <MultiTrigger.Conditions>
                                            <Condition Property="IsSelected" Value="true"/>
                                            <Condition Property="IsMouseOver" Value="true"/>
                                        </MultiTrigger.Conditions>
                                        <Setter Property="Background" TargetName="Bd" Value="Red"/>
                                    </MultiTrigger>
                                    <Trigger Property="IsEnabled" Value="false">
                                        <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
                                    </Trigger>
        
        
                                    <!--begin: I added just this, but you can cleanup your xaml and made it better, this just showing how you can do-->
                                    <MultiDataTrigger>
                                        <MultiDataTrigger.Conditions>
                                            <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsSelected}" Value="true"/>
                                            <Condition Binding="{Binding RelativeSource={RelativeSource Self}, Path=IsMouseOver}" Value="true"/>
                                            <Condition Binding="{Binding ElementName=ItemsHost, Path=IsMouseOver}" Value="True"/>
                                        </MultiDataTrigger.Conditions>
                                        <Setter Property="Background" TargetName="Bd" Value="Green"/>
                                    </MultiDataTrigger>
                                    <!--end-->
        
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
