    private void button1_Click(object sender, EventArgs e) {
            Process[] plist = Process.GetProcesses();
            foreach (Process p in plist) {
                if (p.ProcessName == "notepad") {
                    AutomationElement ae = AutomationElement.FromHandle(p.MainWindowHandle);
                    AutomationElement npEdit = ae.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ClassNameProperty, "Edit"));
                    TextPattern tp = npEdit.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
                    TextPatternRange[] trs;
                    if (tp.SupportedTextSelection == SupportedTextSelection.None) {
                        return;
                    }
                    else {
                        trs = tp.GetSelection();
                        lblSelectedText.Text = trs[0].GetText(-1);
                    }
                }
            }
        }
