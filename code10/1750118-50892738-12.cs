        public class MyClassA : IEquatable<List<MyClassB>>
        {
            public List<MyClassB> myClassB { get; set; }
            public bool Equals(List<MyClassB> other)
            {
                if(other == null) return false;
                if (this.myClassB.Count() != other.Count()) return false;
                var groupThis = this.myClassB.OrderBy(x => x.propertyA).ThenBy(x => x.propertyB).GroupBy(x => x).ToList();
                var groupOther = other.OrderBy(x => x.propertyA).ThenBy(x => x.propertyB).GroupBy(x => x).ToList();
                if (groupThis.Count() != groupOther.Count) return false;
                for (int i = 0; i < groupThis.Count(); i++)
                {
                    if (groupThis[i].Count() != groupOther[i].Count()) return false;
                }
                return true;
            }
            public override int GetHashCode()
            {
                return 0;
            }
        }
        public class MyClassB : IEquatable<MyClassB>
        {
            public int propertyA { get; set; }
            public string propertyB { get; set; }
            public bool Equals(MyClassB other)
            {
                if (other == null) return false;
                if ((this.propertyA == other.propertyA) && (this.propertyB == other.propertyB))
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
                return 0;
            }
        }
