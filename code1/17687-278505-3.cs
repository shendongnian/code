    private void button1_Click(object sender, EventArgs e)
    {
        selectedServer = "JS000943";
        listBox1.Items.Add(GetProcessorIdleTime(selectedServer).ToString());
    }
    private static int GetProcessorIdleTime(string selectedServer)
    {
        try
        {
            var searcher = new
               ManagementObjectSearcher
                 (@"\\"+ selectedServer +@"\root\CIMV2",
                  "SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor WHERE Name=\"_Total\"");
            ManagementObjectCollection collection = searcher.Get();
            ManagementObject queryObj = collection.Cast<ManagementObject>().First();
            return Convert.ToInt32(queryObj["PercentIdleTime"]);
        }
        catch (ManagementException e)
        {
            MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
        }
        return -1;
    }
