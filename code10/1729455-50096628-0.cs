        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RTB_Main.Document.Blocks.Clear();
            for (int i = 0; i < 10; i++)
            {
                Paragraph para = new Paragraph(new Run(i + ""));
                RTB_Main.Document.Blocks.Add(para);
            }
            TextRange richText = new TextRange(RTB_Main.Document.ContentStart, RTB_Main.Document.ContentEnd);
            string searchText = tb_Search.Text; // 1 to 9
            string tmpStr = richText.Text.Replace("\r\n", "....");
            int position = Regex.Match(tmpStr, searchText).Index;
            RTB_Main.CaretPosition = RTB_Main.Document.ContentStart;
            RTB_Main.CaretPosition = RTB_Main.CaretPosition.GetPositionAtOffset(position);
            RTB_Main.Focus();
        }
