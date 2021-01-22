            int destinationX = (Screen.PrimaryScreen.WorkingArea.Width / 2) - (this.Width / 2);
            int destinationY = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            Point newLocation = new Point(destinationX, destinationY + this.Height);
            new Thread(new ThreadStart(() =>
            {
                do
                {
                     // this line needs to be executed in the UI thread, hence we use Invoke
                    this.Invoke(new Action(() => { this.Location = newLocation; }));
                    newLocation = new Point(destinationX, newLocation.Y - 1);
                    System.Threading.Thread.Sleep(100);
                }
                while (newLocation != new Point(destinationX, destinationY));
            })).Start();
