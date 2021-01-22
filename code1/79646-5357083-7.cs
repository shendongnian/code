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
        namespace IdiotProofNumericTextBox
        {
            public partial class Window1 : Window
            {
                private string previousText;
                public Window1()
                {
                    InitializeComponent();
                    previousText = numericTB.Text;
                }
                private void numericTB_TextChanged(object sender, TextChangedEventArgs e)
                {
                    if (string.IsNullOrEmpty(((TextBox)sender).Text))
                        previousText = "";
                    else
                    {
                        double num = 0;
                        bool success = double.TryParse(((TextBox)sender).Text, out num);
                        if (success & num >= 0)
                        {
                            ((TextBox)sender).Text.Trim();
                            previousText = ((TextBox)sender).Text;
                        }
                        else
                        {
                            ((TextBox)sender).Text = previousText;
                            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
                        }
                    }
                }
            }
        }
