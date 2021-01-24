        private void MenuControl_ItemClick(object sender, ItemClickEventArgs e)
        {
            HamburgerMenuGlyphItem i = e.ClickedItem as HamburgerMenuGlyphItem;
            if(i != null)
            {
                UserControl uc = new UserControl();
                switch(i.Tag.ToString())
                {
                    case "main":
                        uc = new Views.main(tc);
                        break;
                    case "testsystems":
                        uc = new Views.testsystems();
                        break;
                }
                i.Tag = uc;
                this.MenuControl.Content = i;
            }
        }
