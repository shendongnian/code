    <ControlTemplate TargetType="{x:Type TreeViewItem}" x:Key="ItemTemplate">
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
                <ToggleButton x:Name="Expander" ClickMode="Press" IsChecked="{Binding IsExpanded, RelativeSource={RelativeSource TemplatedParent}}" Style="{DynamicResource TreeViewItemToggleButtonStyle}"/>
                <Border x:Name="Bd" BorderBrush="{TemplateBinding BorderBrush}" BorderThickness="{TemplateBinding BorderThickness}" Background="{TemplateBinding Background}" Grid.Column="1" Padding="{TemplateBinding Padding}" SnapsToDevicePixels="True">
                    <ContentPresenter x:Name="PART_Header" ContentTemplate="{TemplateBinding HeaderTemplate}" Content="{TemplateBinding Header}" ContentStringFormat="{TemplateBinding HeaderStringFormat}" ContentSource="Header" HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}" SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                </Border>
                <ItemsPresenter x:Name="ItemsHost" Grid.ColumnSpan="2" Grid.Column="1" Grid.Row="1"/>
            </Grid>
            <ControlTemplate.Triggers>
                <Trigger Property="IsExpanded" Value="False">
                    <Setter Property="Visibility" TargetName="ItemsHost" Value="Collapsed"/>
                </Trigger>
                <!-- Commented trigger -->
                <!--<Trigger Property="HasItems" Value="False">
                    <Setter Property="Visibility" TargetName="Expander" Value="Hidden"/>
                </Trigger>-->
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
