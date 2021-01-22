        public void Test1()
        {
            List<List<String>> list = new List<List<string>>() { 
                new List<String>() { "XYZ", "ABC","100" },
                new List<String>() { "X", "ABC", "100"},
            };
            string text = "", a = "", b = "", c = "";
            for (int i = 0; i < list.Count; i++)
            {
                a = list[i][0];
                b = list[i][1];
                c = list[i][2];
                text += String.Format("{0, -8} {1,-4} {2,8}{3}", a, b, c, Environment.NewLine);
            }
            MessageBox.Show(text);
        }
