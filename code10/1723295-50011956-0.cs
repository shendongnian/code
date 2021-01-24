        private void ListDemo()
        {
            var l = new List<string>();
            l.Add("A");
            BindingList<string> blist1 = new BindingList<string>(l);
            BindingList<string> blist2 =new BindingList<string>(l);
            blist1.ListChanged += Blist1_ListChanged;
            blist2.ListChanged += Blist2_ListChanged;
            blist1.Add("B");
            // at this point blist1 and blist2 items count is 2 but only blist1 raised ListChanged
        }
        private void Blist2_ListChanged(object sender, ListChangedEventArgs e)
        {
            //No event fired here when adding B
        }
        private void Blist1_ListChanged(object sender, ListChangedEventArgs e)
        {
           // event fired when adding B
        }
