        using System;
        using System.Windows;
        using System.Windows.Controls;
        
        namespace AddControlsDynamically
        {
            public partial class Window1 : Window
            {
                public void Window_Loaded(object sender, RoutedEventArgs e)
                {
                    GenerateControls();
                }
                public void GenerateControls()
                {
                    Button btnClickMe = new Button();
                    btnClickMe.Content = "Click Me";
                    btnClickMe.Name = "btnClickMe";
                    btnClickMe.Click += new RoutedEventHandler(this.CallMeClick);
                    someStackPanel.Children.Add(btnClickMe);
                    TextBox txtNumber = new TextBox();
                    txtNumber.Name = "txtNumber";
                    txtNumber.Text = "1776";
                    someStackPanel.Children.Add(txtNumber);
                    someStackPanel.RegisterName(txtNumber.Name, txtNumber);
                }
                protected void CallMeClick(object sender, RoutedEventArgs e)
                {
                    TextBox txtNumber = (TextBox) this.someStackPanel.FindName("txtNumber");
                    string message = string.Format("The number is {0}", txtNumber.Text);
                    MessageBox.Show(message);
                }
            }
        }
