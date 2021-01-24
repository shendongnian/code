    <ContentDialog ...
        x:Class="MyApp1.ContentDialog1"
        Title="MyDialog"
        PrimaryButtonText="Ok"
        SecondaryButtonText="Cancel"
        Loaded="ContentDialog_Loaded"
        PrimaryButtonClick="ContentDialog_PrimaryButtonClick"
        SecondaryButtonClick="ContentDialog_SecondaryButtonClick">
    <Grid Name="A1Grid">
        <Grid.RowDefinitions>
            <RowDefinition Height="auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <TextBox Name="A1TextBox" Grid.Row="0" 
             PlaceholderText="Search String" 
             TextChanged="A1TextBox_TextChanged"/>
        <ScrollViewer Grid.Row="1"
           ScrollViewer.VerticalScrollBarVisibility="Auto"
           VerticalAlignment="Stretch">
            <ListBox Name="A1ListBox" MinHeight="200"/>
        </ScrollViewer>
        </Grid>
    </ContentDialog>
    public sealed partial class ContentDialog1 : ContentDialog
    {
        List<string> Choices = new List<string>
            {
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine",
                "Ten",
                "Eleven",
                "Twelve",
                "13",
                "14",
                "15",
                "16",
                "17",
                "18",
                "19",
                "20"
        };
        public ContentDialog1()
        {
            this.InitializeComponent();
            A1ListBox.ItemsSource = Choices;
            A1Grid.MinWidth  = Window.Current.Bounds.Width * 0.80;
            A1Grid.MinHeight = Window.Current.Bounds.Height * 0.80;
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
