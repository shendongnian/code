        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var senderList  = (ListView) sender;
            var clickedItem = senderList.HitTest(e.Location).Item;
            if (clickedItem != null)
            {
                //do something
            }            
        }
