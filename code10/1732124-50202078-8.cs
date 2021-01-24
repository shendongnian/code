    using System;
    using System.Linq;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using System.Collections.Generic;
    public sealed partial class ContentDialog1 : ContentDialog
    {
        List<string> Choices = new List<string>
        {
                "One", "Two", "Three", "Four",
                "Five", "Six", "Seven", "Eight",
                "Nine", "Ten", "Eleven", "Twelve",
                "13", "14", "15", "16",
                "17", "18", "19",
                "20"
        };
        public ContentDialog1()
        {
            this.InitializeComponent();
            A1ListBox.ItemsSource = Choices;
            this.IsPrimaryButtonEnabled = false;
        }
        private void A1TextBox_TextChanged(
            object sender, 
            TextChangedEventArgs e)
        {
            this.IsPrimaryButtonEnabled = false;
            string text = A1TextBox.Text;
            if (string.IsNullOrEmpty(text))
            {
                A1ListBox.ItemsSource = Choices;
            }
            else
            {
                string search = text.ToLower();
                List<string> list = Choices.Where(
                        x => x.ToLower().Contains(search))
                        .ToList();
                A1ListBox.ItemsSource = list;
                if (list.Count != 0)
                {
                    this.IsPrimaryButtonEnabled = true;
                    A1ListBox.SelectedIndex = 0;
                }
            }
        }
        // OK Button
        private void ContentDialog_PrimaryButtonClick(
             ContentDialog sender, 
             ContentDialogButtonClickEventArgs args)
        {
        }
        // Cancel Button
        private void ContentDialog_SecondaryButtonClick(
              ContentDialog sender, 
              ContentDialogButtonClickEventArgs args)
        {
        }
        private void ContentDialog_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
