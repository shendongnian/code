    public class NewsItemJoiner : NewsItem
    {
        // ...
        public override string Render() {
            return String.Format("{0} has just joined our music network.", this.AccountJoined.ArtistName);
        }
    }
