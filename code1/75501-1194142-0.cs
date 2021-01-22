        System.DateTime _lastChangeInSearchText;
        private const int DELAY_IN_MILLISECONDS = 600;
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            _lastChangeInSearchText = System.DateTime.Now;
            string textToFind = tbSearch.Text;
            if ((textToFind != null) && (textToFind != ""))
                System.Threading.ThreadPool.QueueUserWorkItem(new WaitCallback(MaybeDoSearch), textToFind);
            else 
            {
                // clear the ListView that contains the search results 
                this.ListView2.Items.Clear();
            }
        }
        private void MaybeDoSearch(object o)
        {
            System.Threading.Thread.Sleep(DELAY_IN_MILLISECONDS);
            System.DateTime now = System.DateTime.Now;
            var _delta = now - _lastChangeInSearchText;
            if (_delta >= new System.TimeSpan(0,0,0,0,DELAY_IN_MILLISECONDS))
            {
                // actually do the search
                ShowSearchResults();
            }
        }
