        private yourDataType orderDataGridItems;
        public yourDataType OrderDataGridItems
        {
            get { return orderDataGridItems; }
            set
            {
                orderDataGridItems = value;
                NotifyChange("OrderDataGridItems");
            }
        }
