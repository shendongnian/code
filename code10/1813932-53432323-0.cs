    public class SomeWindow
    {
        public String systemInformation = "";
    
        public SomeWindow()
        {
            InitWhatever();
            RefreshSystemData();
        }
    
        private RefreshSystemData()
        {
            systemInformation = getCPU();
            systemInformation += "Memory:  " + getRAMsize() + Environment.NewLine;
            systemInformation += "Free Space:  " + GetTotalFreeSpace(sysdrive) + " GB" + Environment.NewLine;
            if (Is64BitSystem)
            {
                systemInformation += getOS() + " 64bit" + Environment.NewLine;
            }
            else
            {
                systemInformation += getOS() + " 32 Bit" + Environment.NewLine;
            }
            systemInformation += "MAC Address : " + System.Text.RegularExpressions.Regex.Replace(GetMacAddress().ToString(), ".{2}", "$0 ") + Environment.NewLine;
            systemInformation += av();
            NotifyOfPropertyChange(() => systemInformation);
        }
    
    }
