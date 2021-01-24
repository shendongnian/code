            var mu = new MessageUpdater();
            var counter = 0;
            var timer = new System.Threading.Timer((System.Threading.TimerCallback)(x =>
            {
                mu.SendMessage((counter++).ToString());
            }), null, TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0));
            var ab = new AlertBox();
            ab.MessageUpdater = mu;
            ab.ShowDialog();
