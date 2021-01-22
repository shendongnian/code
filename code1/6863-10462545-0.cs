    /*The simplest way to get/display total physical memory in VB.net (Tested)
    public sub get_total_physical_mem()
        dim total_physical_memory as integer
        total_physical_memory=CInt((My.Computer.Info.TotalPhysicalMemory) / (1024 * 1024))
        MsgBox("Total Physical Memory" + CInt((My.Computer.Info.TotalPhysicalMemory) / (1024 * 1024)).ToString + "Mb" )
    end sub
    */
    //The simplest way to get/display total physical memory in C# (converted Form http://www.developerfusion.com/tools/convert/vb-to-csharp)
    
    public void get_total_physical_mem()
    {
    	int total_physical_memory = 0;
    	total_physical_memory = Convert.ToInt32((My.Computer.Info.TotalPhysicalMemory) /  (1024 * 1024));
    	Interaction.MsgBox("Total Physical Memory" + Convert.ToInt32((My.Computer.Info.TotalPhysicalMemory) / (1024 * 1024)).ToString() + "Mb");
    }
