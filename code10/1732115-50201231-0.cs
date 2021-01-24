    public class OnScrollListenerWallet : RecyclerView.OnScrollListener
        {
            public override void OnScrollStateChanged(RecyclerView recyclerView, int newState)
            {
                base.OnScrollStateChanged(recyclerView, newState);
                int pos = 0;
                if (newState == RecyclerView.ScrollStateIdle)
                {
                    pos = ln.FindFirstVisibleItemPosition();
                    myPassedTextView.Text = myCollection[pos].Name;
                }
            }
        }
