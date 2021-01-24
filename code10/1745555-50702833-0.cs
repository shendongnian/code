    Random rnd = new Random();
                int x = 0;
                int y = rnd.Next(2);
                var buttonName = "button" + (x.ToString() + y.ToString());
                var buttonControl = this.FindName(buttonName) as Button;
                if (buttonControl != null)
                {
                    buttonControl.RaiseEvent(new RoutedEventArgs(Button.ClickEvent, buttonControl));
                }
