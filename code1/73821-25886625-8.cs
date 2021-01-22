        private void ButtonNewActionOnClick(object sender, EventArgs e)
        {
            new Thread(TestNewAction).Start();
        }
        private void TestNewAction()
        {
            var watch = Stopwatch.StartNew();
            for (var i = 0; i < COUNT; i++)
            {
                SetVisibleByNewAction();
            }
            watch.Stop();
            Append("New Action: " + watch.ElapsedMilliseconds + "ms");
        }
