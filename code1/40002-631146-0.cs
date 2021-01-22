    <Grid xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
          xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml">
        <Grid.Resources>
            <x:Array x:Key="colors" Type="{x:Type Color}">
                <Color>Green</Color>
                <Color>Red</Color>
                <Color>Blue</Color>
                <Color>Orange</Color>
                <Color>Yellow</Color>
                <Color>Violet</Color>
            </x:Array>
            <DataTemplate DataType="{x:Type Color}">
                <Border x:Name="brd" Height="20" Width="20">
                    <Border.Background>
                        <SolidColorBrush Color="{Binding}"/>
                    </Border.Background>
                    <Border.RenderTransform>
                        <ScaleTransform CenterX="10" CenterY="10"/>
                    </Border.RenderTransform>
                    <Border.Style>
                        <Style TargetType="{x:Type Border}">
                            <Style.Triggers>
                                <Trigger Property="IsMouseOver" Value="True">
                                    <Setter Property="BorderThickness" Value="2"/>
                                    <Setter Property="BorderBrush" Value="Black"/>
                                </Trigger>
                            </Style.Triggers>
                        </Style>
                    </Border.Style>
                    <Border.Triggers>
                        <EventTrigger RoutedEvent="Border.MouseEnter">
                            <BeginStoryboard>
                                <Storyboard>
                                   <DoubleAnimation Duration="0:0:0.5" Storyboard.TargetName="brd" Storyboard.TargetProperty="RenderTransform.ScaleX" To="1.5"/>
                                   <DoubleAnimation Duration="0:0:0.5" Storyboard.TargetName="brd" Storyboard.TargetProperty="RenderTransform.ScaleY" To="1.5"/>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger>
                        <EventTrigger RoutedEvent="Border.MouseLeave">
                            <BeginStoryboard>
                                <Storyboard>
                                   <DoubleAnimation Duration="0:0:0.5" Storyboard.TargetName="brd" Storyboard.TargetProperty="RenderTransform.ScaleX" To="1"/>
                                   <DoubleAnimation Duration="0:0:0.5" Storyboard.TargetName="brd" Storyboard.TargetProperty="RenderTransform.ScaleY" To="1"/>
                                </Storyboard>
                            </BeginStoryboard>
                      </EventTrigger>
                    </Border.Triggers>
                </Border>
            </DataTemplate>
        <Style TargetType="{x:Type ContentPresenter}">
            <Style.Triggers>
                <Trigger Property="IsMouseOver" Value="True">
                    <Setter Property="Panel.ZIndex" Value="99999"/>
                </Trigger>
            </Style.Triggers>
        </Style>
        </Grid.Resources>
        <ItemsControl ItemsSource="{StaticResource colors}" Margin="20" Width="40">
            <ItemsControl.ItemsPanel>
                <ItemsPanelTemplate>
                    <WrapPanel/>
                </ItemsPanelTemplate>
            </ItemsControl.ItemsPanel>
        </ItemsControl>
    </Grid>
