TextblockWithTooltip.xaml
    <UserControl x:Name="root"
                 x:Class="WpfApp4.TextblockWithTooltip"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                 mc:Ignorable="d" 
                d:DesignHeight="450" d:DesignWidth="800">
        <UserControl.Resources>
            
        </UserControl.Resources>
        <Grid>
            <Grid.Resources>
                <Style TargetType="ToolTip" x:Key="ToolTipWrap">
                    <Style.Resources>
                        <Style TargetType="ContentPresenter">
                            <Style.Resources>
                                <Style TargetType="TextBlock">
                                    <Setter Property="TextWrapping" Value="Wrap" />
                                </Style>
                            </Style.Resources>
                        </Style>
                    </Style.Resources>
                    <Setter Property="MaxWidth" Value="100" />
                </Style>
            </Grid.Resources>
            <TextBlock x:Name="TooltippedTextblock"
                   Text="{Binding DisplayText, ElementName=root}"
                   ToolTipOpening="TooltippedTextblock_OnToolTipOpening">
                <TextBlock.ToolTip>
                    <ToolTip x:Name="MainToolTip" Style="{StaticResource ToolTipWrap}" />
                </TextBlock.ToolTip>
            </TextBlock>
        </Grid>
    </UserControl>
TextblockWtihTooltip.xaml.cs
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApp4
    {
        public partial class TextblockWithTooltip
        {
            public TextblockWithTooltip()
            {
                InitializeComponent();
            }
    
            public static readonly DependencyProperty DisplayTextPropery =
                DependencyProperty.Register(
                    nameof(DisplayText),
                    typeof(string),
                    typeof(TextblockWithTooltip),
                    new PropertyMetadata(string.Empty));
    
            public static readonly DependencyProperty TooltipTextPropery =
                DependencyProperty.Register(
                    nameof(TooltipText),
                    typeof(string),
                    typeof(TextblockWithTooltip),
                    new PropertyMetadata(string.Empty));
    
            public string DisplayText
            {
                get => (string)GetValue(DisplayTextPropery);
                set => SetValue(DisplayTextPropery, value);
            }
    
            public string TooltipText
            {
                get => (string)GetValue(TooltipTextPropery);
                set => SetValue(TooltipTextPropery, value);
            }
    
            private void TooltippedTextblock_OnToolTipOpening(object sender, ToolTipEventArgs e)
            {
                MainToolTip.Content = TooltipText;
            }
        }
    }
