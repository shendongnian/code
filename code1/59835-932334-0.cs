            #region IComparable Members
            public int CompareTo(Result obj)
            {
                if (this.Rank.CompareTo(obj.Rank) != 0)
                    return this.Rank.CompareTo(obj.Rank);
                if (this.Wins.CompareTo(obj.Wins) != 0)
                    return (this.Wins.CompareTo(obj.Wins);
                    
                return (this.TotalScore.CompareTo(obj.TotalScore) ;
            }
            #endregion
