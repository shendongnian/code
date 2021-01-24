    using System;
    using System.IO;
    using System.Windows;
    using Microsoft.Win32;
    
    namespace WpfTutorialSamples.Dialogs
    {
    	public partial class OpenFileDialogSample : Window
    	{
    		public OpenFileDialogSample()
    		{
    			InitializeComponent();
    		}
    
    		private void ShowFilePicker_OnClick(object sender, RoutedEventArgs e)
    		{
                var viewModel = this.DataContext as ViewModel;
    			OpenFileDialog openFileDialog = new OpenFileDialog();
    			if(openFileDialog.ShowDialog() && viewModel.CanOpenFile(openFileDialog.FileName))
    	        {
                   viewModel.OpenFileCommand.Execute(openFileDialog.FileName);
                }
    		}
    	}
    }
