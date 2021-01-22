    <UserControl x:Class="Testproject.EditableDataGrid"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" 
        xmlns:data="clr-namespace:System.Windows.Controls;assembly=System.Windows.Controls.Data"
        Width="400" Height="300">
        <Grid x:Name="LayoutRoot" Background="White">
            <data:DataGrid x:Name="myDataGrid" AutoGenerateColumns="False"> 
                <data:DataGrid.Columns>
                    <data:DataGridTextColumn Header="My text" Binding="{Binding StringValue}" />
                    <data:DataGridCheckBoxColumn Header="Check Box" Binding="{Binding IsChecked}" />
                    <data:DataGridTemplateColumn Header="A template column">
                        <data:DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <StackPanel Orientation="Horizontal">
                                <Rectangle Width="20" Height="5" Fill="Red"/>
                                <TextBlock Text="{Binding IntValue}" />
                            </StackPanel>
                        </DataTemplate>
                    </data:DataGridTemplateColumn.CellTemplate>
                    
                </data:DataGridTemplateColumn>
                    <data:DataGridTextColumn Header="My int" Binding="{Binding IntValue}" />
                </data:DataGrid.Columns>
            </data:DataGrid>
        </Grid>
    </UserControl>
    using System.Windows;
    using System.Windows.Controls;
    using System.Collections.Generic;
    namespace Testproject
    {
        public partial class EditableDataGrid   :UserControl
        {
            public EditableDataGrid()
            {
                InitializeComponent();
                myDataGrid.ItemsSource = new List<ClassForDataGridTest>()
                                {
                                    new ClassForDataGridTest() {StringValue="hello", IntValue=21, IsChecked=false}
                                    , new ClassForDataGridTest() {StringValue="the second", IntValue=122, IsChecked = true}
                                };
            }
        }
        public class ClassForDataGridTest   : DependencyObject
        {
            public string StringValue {get; set;}
            public int IntValue {get; set;}
            public bool IsChecked { get; set; }
        }
    }
