        public class Meb : IEquatable<Meb>, INotifyPropertyChanged
        {
            public int ID { get; set; }
            public int Number { get; set; }
            public int Length { get; set; }
            public int Quantity { get; set;}
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(string propertyName = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            private List<Meb> GroupIdenticalMeb(List<Meb> mebInput)
            {
                return mebInput.GroupBy(x => x).Select(x => new Meb() {
                    ID = x.First().ID,
                    Number = x.First().Number,
                    Length = x.First().Length,
                    Quantity = x.Sum(y => y.Quantity)
                }).ToList();
            }
            public bool Equals(Meb other)
            {
                if ((this.Number == other.Number) && (this.Length == other.Length) && (this.Quantity == other.Quantity))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override int GetHashCode()
            {
                return ID;
            }
        }
