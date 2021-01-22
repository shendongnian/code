        public string between2finer(string line, string delimiterFirst, string delimiterLast)
        {
            string[] splitterFirst = new string[] { delimiterFirst };
            string[] splitterLast = new string[] { delimiterLast };
            string[] splitRes;
            string buildBuffer;
            splitRes = line.Split(splitterFirst, 100000, System.StringSplitOptions.RemoveEmptyEntries);
            buildBuffer = splitRes[1];
            splitRes = buildBuffer.Split(splitterLast, 100000, System.StringSplitOptions.RemoveEmptyEntries);
            return splitRes[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string manyLines = "Received: from exim by isp2.ihc.ru with local (Exim 4.77) \nX-Failed-Recipients: rmnokixm@gmail.com\nFrom: Mail Delivery System <Mailer-Daemon@isp2.ihc.ru>";
            MessageBox.Show(between2finer(manyLines, "X-Failed-Recipients: ", "\n"));
        }
