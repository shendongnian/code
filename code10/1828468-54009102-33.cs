    using System;
    using System.IO;
    using System.Windows;
    using Microsoft.Win32;
    
    namespace WpfOpenDialogExample
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
    			if(openFileDialog.ShowDialog() == true && viewModel.OpenFileCommand.CanExecute(openFileDialog.FileName))
    	        {
                   viewModel.OpenFileCommand.Execute(openFileDialog.FileName);
                }
    		}
    
    		private void ShowFolderPicker_OnClick(object sender, RoutedEventArgs e)
    		{
                var viewModel = this.DataContext as ViewModel;
    			FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
    			if(openFolderDialog.ShowDialog() == DialogResul.Ok && viewModel.OpenFolderCommand.CanExecute(openFolderDialog.SelectedPath ))
    	        {
                   viewModel.OpenFolderCommand.Execute(openFolderDialog.SelectedPath );
                }
    		}
    	}
    }
