    public partial class Window1 : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Random random = new Random(DateTime.Now.Millisecond);
        // Some general values
        double MaxSize = 150;
        double NumberOfParticles = 25;
        double VerticalVelocity = 0.4;
        double HorizontalVelocity = -2.2;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < NumberOfParticles; i++)
            {
                CreateParticle();
            }
            timer.Interval = TimeSpan.FromMilliseconds(33.33);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            // I control "particle" from their ellipse representation
            foreach (Ellipse ellipse in ParticleHost.Children)
            {
                var p = ellipse.Tag as Particle;
                var t = ellipse.RenderTransform as TranslateTransform;
                // Update location
                t.X += p.Velocity.X;
                t.Y -= p.Velocity.Y;
                // Check if the particle is too high
                if (t.Y < -MaxSize)
                {
                    t.Y = Height + MaxSize;
                }
                // Check if the particle has gone outside
                if (t.X < -MaxSize || t.X > Width + MaxSize)
                {
                    t.X = random.NextDouble() * Width;
                    t.Y = Height + MaxSize;
                }
                // Brush & Effect
                ellipse.Fill = p.Brush;
                // Comment this line to deactivate the Blur Effect
                ellipse.Effect = p.Blur;
            }
        }
        private void CreateParticle()
        {
            // Brush (White)
            var brush = Brushes.White.Clone();
            // Opacity (0.2 <= 1)
            brush.Opacity = 0.2 + random.NextDouble() * 0.8;
            // Blur effect
            var blur = new BlurEffect();
            blur.RenderingBias = RenderingBias.Performance;
            // Radius (1 <= 40)
            blur.Radius = 1 + random.NextDouble() * 39;
            // Ellipse
            var ellipse = new Ellipse();
            // Size (from 15% to 95% of MaxSize)
            ellipse.Width = ellipse.Height = MaxSize * 0.15 + random.NextDouble() * MaxSize * 0.8;
            // Starting location of the ellipse (anywhere in the screen)
            ellipse.RenderTransform = new TranslateTransform(random.NextDouble() * Width, random.NextDouble() * Height);
            ellipse.Tag = new Particle
            {
                Blur = blur,
                Brush = brush,
                Velocity = new Point
                {
                    X = HorizontalVelocity + random.NextDouble() * 4,
                    Y = VerticalVelocity + random.NextDouble() * 2
                }
            };
            // Add the ellipse to the Canvas
            ParticleHost.Children.Add(ellipse);
        }
    }
