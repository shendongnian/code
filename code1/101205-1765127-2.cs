    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
    public struct SYSTEM_OUTPUT
    {
        UInt16 ReadyForConnect;        
    
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        String VersionStr;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        String NameOfFile;    
        // actually more of those
    }
    
    public partial class Form1 : Form
    {
        public SYSTEM_OUTPUT output;
    
        [DllImport("testeshm.dll", EntryPoint="getStatus")]
        public extern static int getStatus(IntPtr output);
    
        public Form1()
        {
            InitializeComponent();           
    
        }
    
        private void ReadSharedMem_Click(object sender, EventArgs e)
        {
    	    IntPtr ptr;
            try
            {
                ptr = Marshall.AllocHGlobal(Marshall.SizeOf(typeof(SYSTEM_OUTPUT)));
                int ret = getStatus(ptr);
    			
                if(ret == 0)
                {
                    output = (SYSTEM_OUTPUT)Marshal.PtrToStructure(ptr, typeof(SYSTEM_OUTPUT));
                }
    			
    		//do something with output
    			
                label1.Text = ret;
            }
            catch (AccessViolationException ave)
            {
                label1.Text = ave.Message;
            }
    		finally
    		{
    			Marshal.FreeHGlobal(ptr);  //make sure to free the memory
    		}
        }
    }
