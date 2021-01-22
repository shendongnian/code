    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace notep
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
    
            }
    
            private void b1_Click(object sender, RoutedEventArgs e)//copy
            {
                Clipboard.SetText(richTextBox1.Selection.Text);
                richTextBox1.Selection.Text = string.Empty;
    
            }
    
            private void b2_Click(object sender, RoutedEventArgs e)//cut
            {
                Clipboard.SetText(richTextBox1.Selection.Text);
            }
    
            private void b3_Click(object sender, RoutedEventArgs e)
            {
             
             richTextBox1.Selection.Text =richTextBox1.Selection.Text + Clipboard.GetText();//paste
            }
        }
    }
