    internal class PullCursor
    {
        public int Position
        {
            get { return this.initialSkip + this.totalRead; }
        }
