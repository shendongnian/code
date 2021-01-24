    <Window.Resources>
        <Style TargetType="{x:Type TreeViewItem}" x:Key="{x:Type TreeViewItem}">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate  TargetType="{x:Type TreeViewItem}">
                        <Border BorderBrush="Black"
                    BorderThickness="1">
                            <Grid>
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition MinWidth="19" Width="Auto"/>
                                    <ColumnDefinition Width="Auto"/>
                                    <ColumnDefinition Width="*"/>
                                </Grid.ColumnDefinitions>
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="Auto"/>
                                    <RowDefinition/>
                                </Grid.RowDefinitions>
                                <ToggleButton x:Name="Expander" ClickMode="Press" IsChecked="{Binding IsExpanded, RelativeSource={RelativeSource TemplatedParent}}">
                                    <ToggleButton.Style>
                                        <Style TargetType="{x:Type ToggleButton}">
                                            <Setter Property="Focusable" Value="False"/>
                                            <Setter Property="Width" Value="16"/>
                                            <Setter Property="Height" Value="16"/>
                                            <Setter Property="Template">
                                                <Setter.Value>
                                                    <ControlTemplate TargetType="{x:Type ToggleButton}">
                                                        <Border Background="Transparent" Height="16" Padding="5" Width="16">
                                                            <Path x:Name="ExpandPath" Data="M0,0 L0,6 L6,0 z" Fill="White" Stroke="#FF818181">
                                                                <Path.RenderTransform>
                                                                    <RotateTransform Angle="135" CenterY="3" CenterX="3"/>
                                                                </Path.RenderTransform>
                                                            </Path>
                                                        </Border>
                                                        <ControlTemplate.Triggers>
                                                            <Trigger Property="IsChecked" Value="True">
                                                                <Setter Property="RenderTransform" TargetName="ExpandPath">
                                                                    <Setter.Value>
                                                                        <RotateTransform Angle="180" CenterY="3" CenterX="3"/>
                                                                    </Setter.Value>
                                                                </Setter>
                                                                <Setter Property="Fill" TargetName="ExpandPath" Value="#FF595959"/>
                                                                <Setter Property="Stroke" TargetName="ExpandPath" Value="#FF262626"/>
                                                            </Trigger>
                                                            <Trigger Property="IsMouseOver" Value="True">
                                                                <Setter Property="Stroke" TargetName="ExpandPath" Value="#FF27C7F7"/>
                                                                <Setter Property="Fill" TargetName="ExpandPath" Value="#FFCCEEFB"/>
                                                            </Trigger>
                                                            <MultiTrigger>
                                                                <MultiTrigger.Conditions>
                                                                    <Condition Property="IsMouseOver" Value="True"/>
                                                                    <Condition Property="IsChecked" Value="True"/>
                                                                </MultiTrigger.Conditions>
                                                                <Setter Property="Stroke" TargetName="ExpandPath" Value="#FF1CC4F7"/>
                                                                <Setter Property="Fill" TargetName="ExpandPath" Value="#FF82DFFB"/>
                                                            </MultiTrigger>
                                                        </ControlTemplate.Triggers>
                                                    </ControlTemplate>
                                                </Setter.Value>
                                            </Setter>
                                        </Style>
                                    </ToggleButton.Style>
                                </ToggleButton>
                                <Border x:Name="Bd" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Grid.Column="1" Padding="{TemplateBinding Padding}" SnapsToDevicePixels="True">
                                    <ContentPresenter x:Name="PART_Header" ContentTemplate="{TemplateBinding HeaderTemplate}" Content="{TemplateBinding Header}" ContentStringFormat="{TemplateBinding HeaderStringFormat}" ContentSource="Header" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                                </Border>
                                <ItemsPresenter x:Name="ItemsHost" Grid.ColumnSpan="2" Grid.Column="1" Grid.Row="1"/>
                            </Grid>
                        </Border>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsExpanded" Value="False">
                                <Setter Property="Visibility" TargetName="ItemsHost" Value="Collapsed"/>
                            </Trigger>
                            <Trigger Property="HasItems" Value="False">
                                <Setter Property="Visibility" TargetName="Expander" Value="Hidden"/>
                            </Trigger>
                            <Trigger Property="IsSelected" Value="True">
                                <Setter Property="Background" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.HighlightBrushKey}}"/>
                                <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.HighlightTextBrushKey}}"/>
                            </Trigger>
                            <MultiTrigger>
                                <MultiTrigger.Conditions>
                                    <Condition Property="IsSelected" Value="True"/>
                                    <Condition Property="IsSelectionActive" Value="False"/>
                                </MultiTrigger.Conditions>
                                <Setter Property="Background" TargetName="Bd" Value="{DynamicResource {x:Static SystemColors.InactiveSelectionHighlightBrushKey}}"/>
                                <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.InactiveSelectionHighlightTextBrushKey}}"/>
                            </MultiTrigger>
                            <Trigger Property="IsEnabled" Value="False">
                                <Setter Property="Foreground" Value="{DynamicResource {x:Static SystemColors.GrayTextBrushKey}}"/>
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
    <Window.DataContext>
        <local:MainWindowViewModel/>
    </Window.DataContext>
    <Grid>
        <TreeView ItemsSource="{Binding Parents}">
