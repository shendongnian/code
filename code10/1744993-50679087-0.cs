    for (i = 0; i < uploadFileList.Count; i++)
    {
    	choosedProjetName = uploadFileList[i];
    	ShowHome();
    	cancel_upload_model_button.Visibility = Visibility.Visible;
    	ModelUploadTXT.Text = "Uploading " + choosedProjetName + FooterProgressBar.Value.ToString("f0") + " % " + (bytesIn / 1000000).ToString("f2") + "Mb /" + (totalBytes / 1000000).ToString("f2") + "Mb";
    	FooterProgressBar.Foreground = Brushes.Orange;                       
        
    	while (percentage < 100)
    	{
    		continue;
    	}
    	
    	projects_tab.IsEnabled = true;
    	wait_for_upload_text.Visibility = Visibility.Hidden;
    	ModelUploadTXT.Text = "Upload done!";
    	FooterProgressBar.Value = 0;
    	FooterProgressBar.Foreground = Brushes.LimeGreen;
    	cancel_upload_model_button.Visibility = Visibility.Hidden;
    	SelectedFileText.Text = "Choose model(s) to import!"; 
    
         try
           {
           uploadClient.Dispose();
           }
         catch (Exception asd)
           {
    
           }
    }
