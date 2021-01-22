    <Window x:Class="DataGridColumnVisibilitySample.Window1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:tk="clr-namespace:Microsoft.Windows.Controls;assembly=WPFToolkit"
        xmlns:l="clr-namespace:DataGridColumnVisibilitySample"
        Title="Window1" Height="300" Width="300">
        <Window.Resources>
            <l:VisibilityConverter x:Key="VisibilityC" />
        </Window.Resources>
        <DockPanel LastChildFill="True">
            <CheckBox DockPanel.Dock="Top" Margin="8" Content="Show Column B" IsChecked="{Binding ShowColumnB}" />
            <tk:DataGrid ItemsSource="{Binding Items}" AutoGenerateColumns="False" CanUserAddRows="False">
                <tk:DataGrid.Columns>
                    <tk:DataGridTextColumn Header="Column A" Binding="{Binding ColumnA}" />
                    <tk:DataGridTextColumn Header="Column B" Binding="{Binding ColumnB}"
                                           Visibility="{Binding (FrameworkElement.DataContext).ShowColumnB,
                                                                RelativeSource={x:Static RelativeSource.Self},
                                                                Converter={StaticResource VisibilityC}}" />
                    <tk:DataGridTextColumn Header="Column C" Binding="{Binding ColumnC}" />
                </tk:DataGrid.Columns>
            </tk:DataGrid>
        </DockPanel>
    </Window>
----------
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;
    using Microsoft.Windows.Controls;
    
    namespace DataGridColumnVisibilitySample
    {
        public partial class Window1 : INotifyPropertyChanged
        {
            public Window1()
            {
                InitializeComponent();
                new DataGridContextHelper();  // Initialize Helper
                Items = Enumerable.Range(1, 3).Select(i => new MyItem {ColumnA = "A" + i, ColumnB = "B" + i, ColumnC = "C" + i}).ToList();
                DataContext = this;
            }
    
            public List<MyItem> Items { get; private set; }
    
            private bool mShowColumnB;
            public bool ShowColumnB
            {
                get { return mShowColumnB; }
                set
                {
                    if (mShowColumnB == value) return;
                    mShowColumnB = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("ShowColumnB"));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    
        public class DataGridContextHelper
        {
            static DataGridContextHelper()
            {
                FrameworkElement.DataContextProperty.OverrideMetadata(typeof(DataGrid),
                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.Inherits, OnDataContextChanged));
            }
    
            public static void OnDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var grid = d as DataGrid;
                if (grid == null) return;
                foreach (var col in grid.Columns)
                    col.SetValue(FrameworkElement.DataContextProperty, e.NewValue);
            }
        }
    
        [ValueConversion(typeof(bool), typeof(Visibility))]
        public class VisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is bool && (bool)value)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    
        public class MyItem
        {
            public string ColumnA { get; set; }
            public string ColumnB { get; set; }
            public string ColumnC { get; set; }
        }
    }
