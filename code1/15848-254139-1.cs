    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public static class ListViewExtensions
    {
	[System.Runtime.InteropServices.StructLayout( LayoutKind.Sequential )]
	public struct HDITEM
	{
		public int mask;
		public int cxy;
		[System.Runtime.InteropServices.MarshalAs( UnmanagedType.LPTStr )]
		public string pszText;
		public IntPtr hbm;
		public int cchTextMax;
		public int fmt;
		public IntPtr lParam;
		// _WIN32_IE >= 0x0300 
		public int iImage;
		public int iOrder;
		// _WIN32_IE >= 0x0500
		public uint type;
		public IntPtr pvFilter;
		// _WIN32_WINNT >= 0x0600
		public uint state;			
			
		[Flags]
		public enum Mask
		{
			Format = 0x4,  // HDI_FORMAT
		};
		[Flags]
		public enum Format
		{
			SortDown = 0x200,	// HDF_SORTDOWN
			SortUp = 0x400,		// HDF_SORTUP
		};
	};
	[System.Runtime.InteropServices.DllImport( "user32.dll", EntryPoint = "SendMessage" )]
	public static extern IntPtr SendMessageHDITEM( IntPtr hWnd, User32.HeaderMessages Msg, IntPtr wParam, ref HDITEM hdItem );
    	public static void SetSortIcon(this System.Windows.Forms.ListView ListViewControl, int ColumnIndex, System.Windows.Forms.SortOrder Order)
    	{
    		IntPtr ColumnHeader = SendMessage(ListViewControl.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
    
    		for (int ColumnNumber = 0; ColumnNumber <= ListViewControl.Columns.Count - 1; ColumnNumber++)
    		{
    			IntPtr ColumnPtr = new IntPtr(ColumnNumber);
    			HDITEM item = new HDITEM();
    			item.mask = HDITEM.Mask.Format;
    			SendMessageHDITEM(ColumnHeader, HDM_GETITEM, ColumnPtr, ref item );
    
    			if (!(Order == System.Windows.Forms.SortOrder.None) && ColumnNumber == ColumnIndex)
    			{
    				switch (Order)
    				{
    					case System.Windows.Forms.SortOrder.Ascending:
    						item.fmt &= ~HDITEM.Format.SortDown;
    						item.fmt |= HDITEM.Format.SortUp;
    						break;
    					case System.Windows.Forms.SortOrder.Descending:
    						item.fmt &= ~HDITEM.Format.SortUp;
    						item.fmt |= HDITEM.Format.SortDown;
    						break;
    				}
    			}
    			else
    			{
    				item.fmt &= ~HDITEM.Format.SortDown & ~HDITEM.Format.SortUp;
    			}
    
    			SendMessageHDITEM(ColumnHeader, HDM_SETITEM, ColumnPtr, ref item);
    		}
    	}
    }
