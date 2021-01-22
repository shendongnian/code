        private Random _random = new Random();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread testThread = new Thread(TestThread);
            testThread.Start();
        }
        private void TestThread()
        {
            for (int i = 0; i < 1000; i++)
            {
                Dispatcher.BeginInvoke((Action)CreateShape);
            }
        }
        private void CreateShape()
        {
            var shape = new Rectangle();
            shape.Width = _random.Next(10, 50);
            shape.Height = _random.Next(10, 50);
            shape.Fill = new SolidColorBrush(Colors.Red);
            Canvas.SetLeft(shape, _random.Next(0, 400));
            Canvas.SetTop(shape, _random.Next(0, 200));
            LayoutRoot.Children.Add(shape);            
        }
