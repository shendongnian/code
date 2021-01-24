     public partial class StockTableViewCell : UITableViewCell
        {
            public int Row;
            public event EventHandler<int> SelectButtonTapped;
    
            public void BindData(PacketAndPacketDetailItem item, bool flag, int row)
            {
                this.Row = row;
                    
                btn_click.TouchUpInside -= OnSelectButtonTapped;
                btn_click.TouchUpInside += OnSelectButtonTapped;
            }
    
            private void OnSelectButtonTapped(object sender, EventArgs e)
            {
                if (SelectButtonTapped != null)
                    SelectButtonTapped(sender, Row);
            }
        }
