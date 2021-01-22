    <Window x:Class="WpfApplication1.MainWindow"
                        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                        Title="MainWindow" Height="350" Width="525">
        <DataGrid ItemsSource="{Binding}" AutoGenerateColumns="False" >
            <DataGrid.Columns>
                <DataGridTextColumn Header="Values" Binding="{Binding Value}" />
            </DataGrid.Columns>
        </DataGrid>
    </Window>
---
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Threading;
    namespace WpfApplication1 {
        public partial class MainWindow : Window {
            public MainWindow() {
                var c = new BindingList<Data>();
                this.DataContext = c;
                // add new item to list on each timer tick
                var t = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1) };
                t.Tick += (s, e) => {
                    if (c.Count >= 10) t.Stop();
                    c.Add(new Data());
                };
                t.Start();
            }
        }
        public class Data : INotifyPropertyChanged {
            public event PropertyChangedEventHandler PropertyChanged = delegate { };
            System.Timers.Timer t;
            static Random r = new Random();
            public Data() {
                // update value on each timer tick
                t = new System.Timers.Timer() { Interval = r.Next(500, 1000) };
                t.Elapsed += (s, e) => {
                    Value = DateTime.Now.Ticks;
                    this.PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                };
                t.Start();
            }
            public long Value { get; private set; }
        }
    }
