     string ProcessorNameString = "ProcessorNameString: not available";
            string memory = "Memory: not availbale ";
            string freeSpace = "Free space: not available";
            //add others 
            try
            {
                ProcessorNameString = Registry.GetValue(@"HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "ProcessorNameString", null).ToString().Replace("(R)", "").Replace("(TM)", "") + Environment.NewLine;
                memory = string.Format("Free Space:{0}DB", getRAMsize() );
                //process others
            }
            catch { 
            
            }
            TextBox1.Text = string.Format("{0}{1}{2}{3}{4}{5}"
                , ProcessorNameString, Environment.NewLine
                , memory, Environment.NewLine
                , freeSpace, Environment.NewLine);
            Clipboard.SetDataObject(TextBox1.Text);
