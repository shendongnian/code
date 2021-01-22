        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StackTrace trace = new StackTrace();
            StackFrame frame;
            bool bFoundExitCommand = false;
            for (int i = 0; i < trace.FrameCount; i++)
            {
                frame = trace.GetFrame(i);
				string methodName = frame.GetMethod().Name;
				if (methodName == "miExit_Click")
				{
					bFoundExitCommand = true;
					Log("FormClosing: Found Exit Command ({0}) - will allow exit", LogUtilityLevel.Debug3, methodName);
				}
				if (methodName == "PeekMessage")
				{
					bFoundExitCommand = true;
					Log("FormClosing: Found System Shutdown ({0}) - will allow exit", LogUtilityLevel.Debug3, methodName);
				}
				Log("FormClosing: frame.GetMethod().Name = {0}", LogUtilityLevel.Debug4, methodName);
            }
			if (!bFoundExitCommand)
            {
                e.Cancel = true;
                this.Visible = false;
            }
            else
            {
                this.Visible = false;
            }
        }
