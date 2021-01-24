     bool Scrolling = true;
            private void listBoxAdv1_Scroll(object sender, ScrollEventArgs e)
            {
                if (Scrolling == true)
                {
                    Scrolling = false;
                    listBoxAdv2.BeginUpdate();
                    listBoxAdv2.AutoScrollPosition = new Point(listBoxAdv1.AutoScrollPosition.X, listBoxAdv1.AutoScrollPosition.Y);
                    listBoxAdv2_Scroll(sender, e);
                    listBoxAdv2.EndUpdate();
                    Scrolling = true;
                }
            }
    
            private void listBoxAdv2_Scroll(object sender, ScrollEventArgs e)
            {
                if (Scrolling == true)
                {
                    Scrolling = false;
                    listBoxAdv1.BeginUpdate();
                    listBoxAdv1.AutoScrollPosition = new Point(listBoxAdv2.AutoScrollPosition.X, listBoxAdv2.AutoScrollPosition.Y);
                    listBoxAdv1_Scroll(sender, e);
                    listBoxAdv1.EndUpdate();
                    Scrolling = true;
                }
            }
