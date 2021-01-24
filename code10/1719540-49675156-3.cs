    using System.Windows;
    using System.Windows.Controls;
    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            /// <summary>
            /// The last unsaved selected item
            /// </summary>
            private object mLastSelectedValue;
            public MainWindow()
            {
                InitializeComponent();
            }
            private void SaveButton_Click(object sender, RoutedEventArgs e)
            {
                // TODO: Save something
                MessageBox.Show("Saved");
                // Clear last value
                mLastSelectedValue = null;
                // Clear combo box selected item
                ComboBox1.SelectedItem = null;
            }
            private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                // Get the desired new value
                var newValue = ((ComboBox)sender).SelectedItem;
                // If value is the last-selected one...
                if (mLastSelectedValue == newValue)
                    // Do nothing else
                    return;
                // If this is a new selection
                if (mLastSelectedValue == null)
                {
                    // Save the new selection
                    mLastSelectedValue = newValue;
                }
                // Otherwise, the value is different...
                else
                {
                    // Restore value
                    ((ComboBox)sender).SelectedItem = mLastSelectedValue;
                    // Show message box
                    MessageBox.Show("Please save your work first");
                }
            }
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                // Add some dummy items
                ComboBox1.Items.Add("Item 1");
                ComboBox1.Items.Add("Item 2");
                ComboBox1.Items.Add("Item 3");
                ComboBox1.Items.Add("Item 4");
            }
        }
    }
