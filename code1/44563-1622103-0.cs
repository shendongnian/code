        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            TextValue<string, int> foo = new TextValue<string, int>("",0);
            foo.Text = "Hi there";
            foo.Value = 3995;
            MessageBox.Show(foo.Text);
        }
        class TextValue<TText, TValue>
        {
            public TextValue(TText text, TValue value)
            {
                Text = text;
                Value = value;
            }
            public TText Text { get; set; }
            public TValue Value { get; set; }
        }
