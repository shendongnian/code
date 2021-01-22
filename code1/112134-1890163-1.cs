    namespace Whatever  
    {  
      public partial class MyWindow : Window  
      {  
        public delegate void CopyDelegate();  
        private string m_strSourceDir;  // Source directory - set elsewhere.  
        private List<string> m_lstrFiles;  // To hold the find result.  
        private string m_strTargetDir;  // Destination directory - set elsewhere.  
        private int m_iFileIndex;  // To keep track of where we are in the list.  
        private ObservableCollection<string> m_osstrProgress;  // To attach to the listbox.  
          
        private void CopyFiles()  
        {  
          if(m_iFileIndex == m_lstrFiles.Count)  
          {  
             System.Windows.MessageBox.Show("Copy Complete");  
             return;  
          }  
            
          string strSource= m_lstrFiles[m_iFileIndex];  // Full path.  
          string strTarget= m_strTargetDir + strSource.Substring(strSource.LastIndexOf('\\'));  
          string strProgress= "Copied \"" + strSource + "\" to \"" + strTarget + '\"';  
          try  
          {  
            System.IO.File.Copy(strFile, strTarget, true);  
          }  
          catch(System.Exception exSys)  
          {  
            strProgress = "Error copying \"" + strSource + "\" to \"" + strTarget + "\" - " + exSys.Message;  
          }  
            
          m_osstrProgress.Add(strProgress);  
          ++m_iFileIndex;  
          lbxProgress.Dispatcher.BeginInvoke(DispatcherPriority.SystemIdle, new CopyDelegate(CopyFiles));  
        }  
          
        private void btnCopy_Click(object sender, RoutedEventArgs e)  
        {  
          m_lstrFiles= new List<String>(System.IO.Directory.GetFiles(m_strSourceDir, "*.exe"));  
          if (0 == m_lstrFiles.Count)  
          {  
            System.Windows.MessageBox.Show("No .exe files found in " + m_strSourceDir);  
            return;  
          }  
            
          if(!System.IO.Directory.Exists(m_strTargetDir))  
          {  
            try  
            {  
              System.IO.Directory.CreateDirectory(m_strTargetDir);  
            }  
            catch(System.Exception exSys)  
            {  
              System.Windows.MessageBox.Show("Unable to create " + m_strTargetDir + ": " + exSys.Message);  
              return;  
            }  
          }  
          
          m_iFileIndex= 0;  
            
          m_osstrProgress= new ObservableCollection<string>();  
          lbxProgress.ItemsSource= m_osstrProgress;  
          lbxProgress.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new CopyDelegate(CopyFiles));  
        }  
      }  
    }  
