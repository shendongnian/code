    private void myTextBlock_Drop(object sender, DragEventArgs e)
    {
             // Mark the event as handled, so TextBox's native Drop handler is not called.
             e.Handled = true;
             Stream sr;
    
              //Explorer 
              if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
                  //Do somthing
    		
    		//Email Message Subject	
    		if (e.Data.GetDataPresent("FileGroupDescriptor"))
            {
    			sr = e.Data.GetData("FileGroupDescriptor") as Stream;
    		        StreamReader sr = new StreamReader(sr2);//new StreamReader(strPath, Encoding.Default);
                //Message Subject
                        string strFullString = sr.ReadToEnd();
             }
                
                
    }
