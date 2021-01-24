    if (System.Windows.Forms.Screen.AllScreens.Length > 1)
            {
                for (int i = 1; i < System.Windows.Forms.Screen.AllScreens.Length; i++)
                {
                    int xPos = System.Windows.Forms.Screen.AllScreens[i].Bounds.Location.X;
                    int yPos = System.Windows.Forms.Screen.AllScreens[i].Bounds.Location.Y;
                    monitorBlackOut screen = new monitorBlackOut();
                    screen.Location = new Point(xPos, yPos);
                    screen.Show();
                    screens.Add(screen);
                }
            }
