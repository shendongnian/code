        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            TextValue<string, int> foo;
            List<TextValue<string, int>> listTextValue = new List<TextValue<string, int>>();
            for (int k = 0; k < 5; ++k)
            {
                foo = new TextValue<string, int>("",0);
                foo.Text = k.ToString();
                foo.Value = k;
                listTextValue.Add(foo);
                otherList.
                MessageBox.Show(foo.Text);
            }
        }
        class TextValue<TText, TValue>
        {
            public TextValue(TText text, TValue value){Text = text; Value = value;}
            public TText Text { get; set; }
            public TValue Value { get; set; }
        }
