    private void lbx1_DragOver(object sender, DragEventArgs e)
    {
       bool dropEnabled = true;
       if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
       {
          string[] filenames = 
                           e.Data.GetData(DataFormats.FileDrop, true) as string[];
          foreach (string filename in filenames)
          {
             if(System.IO.Path.GetExtension(filename).ToUpperInvariant() != ".CS")
             {
                dropEnabled = false;
		break;
             }
           }
       }
       else
       {
          dropEnabled = false;
       }
       if (!dropEnabled)
       {
          e.Effects = DragDropEffects.None;
	  e.Handled = true;
       }			
    }
	private void lbx1_Drop(object sender, DragEventArgs e)
	{
		string[] droppedFilenames = 
                            e.Data.GetData(DataFormats.FileDrop, true) as string[];
	}
