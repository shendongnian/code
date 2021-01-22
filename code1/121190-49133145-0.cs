    public static class Extensions
    {
    	public static void PutFilesOnClipboard(this IEnumerable<FileSystemInfo> filesAndFolders, bool moveFilesOnPaste = false)
    	{
    		var dropEffect = moveFilesOnPaste ? DragDropEffects.Move : DragDropEffects.Copy;
    		
    		var droplist = new StringCollection();
    		droplist.AddRange(filesAndFolders.Select(x=>x.FullName).ToArray());		
    		
    		var data = new DataObject();
    		data.SetFileDropList(droplist);
    		data.SetData("Preferred Dropeffect", new MemoryStream(BitConverter.GetBytes((int)dropEffect)));
    		Clipboard.SetDataObject(data);
    	}
    }
