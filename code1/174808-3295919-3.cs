    <Window x:Class="ReadControlsBackground.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow"
            Height="350"
            Width="525">
    	<StackPanel>
    		<Button x:Name="Start"
    		        Click="Button_Click"
    		        Content="Start" />
    		<ListBox x:Name="List">
    			<ListBoxItem>One</ListBoxItem>
    			<ListBoxItem>Two</ListBoxItem>
    		</ListBox>
    		<CheckBox x:Name="Check" />
    	</StackPanel>
    </Window>
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Windows;
    
    namespace ReadControlsBackground {
        /// <summary>
        ///   Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window {
            public MainWindow() {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e) {
                Start.IsEnabled = false;
                var t = new Thread(Poll);
                t.Start();
            }
    
            private void Poll() {
                while (true) {
                    Debug.WriteLine(String.Format("List: {0}", List.SelectedValue));
                    Debug.WriteLine(String.Format("Check: {0}", Check.IsChecked));
                    Thread.Sleep(5000);
                }
            }
        }
    }
