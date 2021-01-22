    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        static extern bool GetVolumeInformation(string Volume,
            StringBuilder VolumeName, uint VolumeNameSize,
            out uint SerialNumber, out uint SerialNumberLength, out uint flags,
            StringBuilder fs, uint fs_size);
        private void Form1_Load(object sender, EventArgs e)
        {
            uint serialNum, serialNumLength, flags;
            StringBuilder volumename = new StringBuilder(256);
            StringBuilder fstype = new StringBuilder(256);
            bool ok = false;
            Cursor.Current = Cursors.WaitCursor;
            foreach (string drives in Environment.GetLogicalDrives())
            {
                ok = GetVolumeInformation(drives, volumename, (uint)volumename.Capacity - 1, out serialNum,
                                       out serialNumLength, out flags, fstype, (uint)fstype.Capacity - 1);
                if (ok)
                {
                    lblVolume.Text = lblVolume.Text + "\n Volume Information of " + drives + "\n";
                    lblVolume.Text = lblVolume.Text + "\nSerialNumber of is..... " + serialNum.ToString() + " \n";
                    if (volumename != null)
                    {
                        lblVolume.Text = lblVolume.Text + "VolumeName is..... " + volumename.ToString() + " \n";
                    }
                    if (fstype != null)
                    {
                        lblVolume.Text = lblVolume.Text + "FileType is..... " + fstype.ToString() + " \n";
                    }
                }
                ok = false;
            }
            Cursor.Current = Cursors.Default;
        }
