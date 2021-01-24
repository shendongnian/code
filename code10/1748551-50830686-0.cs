    public class POSViewHolder : RecyclerView.ViewHolder
    {
        public event EventHandler MinusClick;
        public event EventHandler PlusClick;
        public TextView ARTnr { get; private set; }
        public TextView ARTbezeichnung { get; private set; }
        public TextView ARTmenge { get; private set; }
        public TextView ARTretourMenge { get; private set; }
        public TextView ARTBELnr { get; private set; }
        public TextView ARTBELart { get; private set; }
        public ImageButton ARTminus { get; set; }
        public ImageButton ARTplus { get; set; }
        public TextView ARTBELlfdnr { get; private set; }
        public POSViewHolder(View itemView) : base(itemView)
        {
            ...
            ARTminus.Click += OnMinusClick;
            Artplus.Click += OnPlusClick;
        }
        private void OnMinusClick(object s, EventArgs e)
        {
            MinusClick?.Invoke(this, EventArgs.Empty);
        }
        private void OnPlusClick(object s, EventArgs e)
        {
            PlusClick?.Invoke(this, EventArgs.Empty);
        }
    }
