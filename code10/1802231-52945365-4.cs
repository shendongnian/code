    <Window.Resources>
        <Style x:Key="SubMenuStyles" TargetType="{x:Type ListViewItem}">
            <Setter Property="Height" Value="40" />
            <Setter Property="Cursor" Value="Hand" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type ListViewItem}">
                        <Border Background="{TemplateBinding Background}"
                                BorderBrush="{TemplateBinding BorderBrush}"
                                BorderThickness="{TemplateBinding BorderThickness}">
                            <ContentPresenter HorizontalAlignment="Left" VerticalAlignment="Center" />
                        </Border>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
            <Style.Triggers>
                <Trigger Property="ListViewItem.IsSelected" Value="True">
                    <Setter Property="Background" Value="#233E4F" />
                    <Setter Property="Foreground" Value="White" />
                    <Setter Property="BorderThickness" Value="50,0,0,0" />
                    <Setter Property="BorderBrush" Value="Orange" />
                </Trigger>
                <MultiTrigger>
                    <MultiTrigger.Conditions>
                        <Condition Property="IsMouseOver" Value="True" />
                        <Condition Property="IsSelected" Value="False" />
                    </MultiTrigger.Conditions>
                    <MultiTrigger.Setters>
                        <Setter Property="BorderBrush" Value="Orange" />
                    </MultiTrigger.Setters>
                    <MultiTrigger.EnterActions>
                        <BeginStoryboard>
                            <Storyboard>
                                <ThicknessAnimation Storyboard.TargetProperty="BorderThickness"
                                                    From="0,0,0,0"
                                                    To="10,0,0,0"
                                                    Duration="0:0:0.5" />
                            </Storyboard>
                        </BeginStoryboard>
                    </MultiTrigger.EnterActions>
                    <MultiTrigger.ExitActions>
                        <BeginStoryboard>
                            <Storyboard>
                                <ThicknessAnimation Storyboard.TargetProperty="BorderThickness"
                                                    From="10,0,0,0"
                                                    To="0,0,0,0"
                                                    Duration="0:0:0.5" />
                            </Storyboard>
                        </BeginStoryboard>
                    </MultiTrigger.ExitActions>
                </MultiTrigger>
            </Style.Triggers>
        </Style>
    </Window.Resources>
    <Grid>
        <ListView Width="200"
                  Height="150"
                  Margin="30">
            <ListViewItem Style="{StaticResource SubMenuStyles}">A ListView</ListViewItem>
            <ListViewItem IsSelected="True" Style="{StaticResource SubMenuStyles}">with several</ListViewItem>
            <ListViewItem Style="{StaticResource SubMenuStyles}">items</ListViewItem>
        </ListView>
    </Grid>
