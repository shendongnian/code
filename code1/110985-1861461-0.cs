    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace UpdateVanillaBindingValue
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {
            private DataClass _data;
    
            public Window1()
            {
                InitializeComponent();
                var data = CreateData();
                DataContext = _data = data;
            }
    
            private DataClass CreateData()
            {
                return new DataClass
                   {
                       Parents=new List<Parent>
                           {
                               new Parent{Name="A",Children=new List<Child>{new Child{Name="A.0"},new Child{Name="A.1"}}},
                               new Parent{Name="B",Children=new List<Child>{new Child{Name="B.0"},new Child{Name="B.1"},new Child{Name="B.2"}}},
                               new Parent{Name="C",Children=new List<Child>{new Child{Name="C.0"},new Child{Name="C.1"}}}
                           }
                   };
            }
    
            private void Rename_Click(object sender, RoutedEventArgs e)
            {
                var parentB = _data.Parents[1];
                var parentBItem = TheTree.ItemContainerGenerator.ContainerFromItem(parentB) as TreeViewItem;
                parentB.Children[1].Name = "Sylvia";
    
                var parentBItemsSource = parentBItem.ItemsSource;
                parentBItem.ItemsSource = null;
                parentBItem.ItemsSource = parentBItemsSource;
            }
        }
    
        public class DataClass
        {
            public List<Parent> Parents { get; set; }
        }
    
        public class Parent
        {
            public string Name { get; set; }
            public List<Child> Children { get; set; }
        }
    
        public class Child
        {
            public string Name { get; set; }
        }
    }
    <Window x:Class="UpdateVanillaBindingValue.Window1"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Window1" Height="300" Width="300">
        <Grid>
            <Grid.Resources>
                <DataTemplate x:Key="ChildTemplate">
                    <TextBlock Margin="50,0,0,0" Text="{Binding Name}" />
                </DataTemplate>
                <HierarchicalDataTemplate x:Key="ParentTemplate" ItemsSource="{Binding Children}" ItemTemplate="{StaticResource ChildTemplate}">
                    <TextBlock Text="{Binding Name}" />
                </HierarchicalDataTemplate>
            </Grid.Resources>
            <TreeView x:Name="TheTree" ItemsSource="{Binding Parents}" ItemTemplate="{StaticResource ParentTemplate}" />
            <Button VerticalAlignment="Bottom" HorizontalAlignment="Center" Content="Rename B.1" Click="Rename_Click" />
        </Grid>
    </Window>
