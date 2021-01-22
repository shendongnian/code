            this.PopUpBorder.MouseLeave += (s, e) =>
            {
                Application.Current.RootVisual.MouseLeftButtonDown += (s1, e1) =>
                {
                    this.PopUp.IsOpen = false;
                };
            };
