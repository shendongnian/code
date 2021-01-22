     public void Log(string msg, Severity severity = Severity.Info)
        {
            string ts = "[" + DateTime.Now.ToString("HH:mm:ss") + "] ";
            string msg2 = ts + msg + "\n";
            richTextBox.AppendText(msg2);
            if (severity > Severity.Info)
            {
                int nlcount = msg2.ToCharArray().Count(a => a == '\n');
                int len = msg2.Length + 3 * (nlcount)+2; //newlines are longer, this formula works fine
                TextPointer myTextPointer1 = richTextBox.Document.ContentEnd.GetPositionAtOffset(-len);
                TextPointer myTextPointer2 = richTextBox.Document.ContentEnd.GetPositionAtOffset(-1);
                
                richTextBox.Selection.Select(myTextPointer1,myTextPointer2);
                SolidColorBrush scb = new SolidColorBrush(GetSeverityColor(severity));
                richTextBox.Selection.ApplyPropertyValue(TextElement.BackgroundProperty, scb);
            }
            richTextBox.ScrollToEnd();
        }
