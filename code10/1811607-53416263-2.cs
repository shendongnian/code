    <Window x:Class="DataGridCell.MainWindow"
              xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
              xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
              xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
              xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
              xmlns:local="clr-namespace:DataGridCell"
              mc:Ignorable="d"
              Title="MainWindow" Height="450" Width="800">
      <DockPanel>
        <StackPanel DockPanel.Dock="Top" Orientation="Horizontal" Background="LightGray">
          <Label Content="Row:"/>
          <TextBox Name="RowTextBox" Text="2"/>
          <Label Content="Column:"/>
          <TextBox Name="ColumnTextBox" Text="1"/>
          <Button DockPanel.Dock="Bottom" Content="Execute Code" Name="ExecuteButton"/>
        </StackPanel>
        <DataGrid Name="MainDataGrid" ItemsSource="{Binding}" AutoGenerateColumns="False" >
          <DataGrid.Columns>
            <DataGridTextColumn Header="Col0" Binding="{Binding Col0}"/>
            <DataGridTextColumn Header="Col1" Binding="{Binding Col1}" />
            <DataGridTextColumn Header="Col2" Binding="{Binding Col2}" />
          </DataGrid.Columns>
        </DataGrid>
      </DockPanel>
    </Window>
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Controls;
    namespace DataGridCell {
      public class RowData {
        public string Col0 { get; set; }
        public string Col1 { get; set; }
        public string Col2 { get; set; }
      }
      public partial class MainWindow: Window {
        public MainWindow() {
          InitializeComponent();
          var dataList = new List<RowData>();
          dataList.Add(new RowData {Col0="0.0", Col1="0.1", Col2="0.2"});
          dataList.Add(new RowData {Col0="1.0", Col1="1.1", Col2="1.2"});
          dataList.Add(new RowData {Col0="2.0", Col1="2.1", Col2="2.2"});
          dataList.Add(new RowData {Col0="3.0", Col1="3.1", Col2="3.2"});
          ObservableCollection<RowData> custdata = new ObservableCollection<RowData>(dataList);
          MainDataGrid.DataContext = custdata;
          ExecuteButton.Click+=ExecuteButton_Click;
        }
        ContentControl cell;
        object oldContent;
        private void ExecuteButton_Click(object sender, RoutedEventArgs e) {
          var row = int.Parse(RowTextBox.Text);
          var col = int.Parse(ColumnTextBox.Text);
          var cellContent = (FrameworkElement)MainDataGrid.Columns[col].GetCellContent(MainDataGrid.Items[row]);
          cell = (ContentControl)cellContent.Parent;
          var button = new Button {Content="Click me" };
          button.Click += Button_Click;
          oldContent = cell.Content;
          cell.Content = button;
          ExecuteButton.IsEnabled = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
          cell.Content = oldContent;
          ExecuteButton.IsEnabled = true;
        }
      }
    }
