        private void EnumRestorePoints()
        {
            System.Management.ManagementClass objClass = new System.Management.ManagementClass("\\\\.\\root\\default", "systemrestore", new System.Management.ObjectGetOptions());
            System.Management.ManagementObjectCollection objCol = objClass.GetInstances();
            StringBuilder Results = new StringBuilder();
            foreach (System.Management.ManagementObject objItem in objCol)
            {
                Results.AppendLine((string)objItem["description"] + Convert.ToChar(9) + ((uint)objItem["sequencenumber"]).ToString());
            }
            MessageBox.Show(Results.ToString());
        }
