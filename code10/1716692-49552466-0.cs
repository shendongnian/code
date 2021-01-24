            string text = @"||Names : XYZ DJ
                             Age : 23 Years
                             Location: New York; end;'
                             2018-03-20 11:59:59.397, mnx=0x0000700, pid=90c9ac, xSG: dlgID:34 AppDlg:774 params:
                             2018-03-20 11:59:59.397, mnx=0x700000, pid=090c9ac, lBG: OPCDManager::Response: 0x7f083
                             2018-03-20 11:59:59.397, mxn=0x000070, pid=f90c9ac, lBG: DlgID:37774 sess:'990' conID:1 dlClose:false params:";
            StringBuilder result = new StringBuilder();
            string[] allLines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string name = allLines[0].Replace("||Names : ", string.Empty).Trim();
            string age = allLines[1].Replace("Age : ", string.Empty).Replace("Years", string.Empty).Trim();
            string location = allLines[2].Replace("Location: ", string.Empty).Replace("; end;'", string.Empty).Trim();
            for(int i = 3; i < allLines.Length; i++)
            {
                result.AppendLine($"{name}-{location},{allLines[i].Trim()}");
            }
            string res = result.ToString();
            Console.WriteLine(res);
