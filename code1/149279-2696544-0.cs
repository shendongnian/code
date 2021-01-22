    [TestFixture]
        public class Tester
        {
            [Test]
            public void SetY()
            {
                var refs = new References();
    
                var x = new X(refs);
                var y = new Y(refs);
    
                x.Y = y;
    
                Assert.AreSame(x.Y, y);
                Assert.AreSame(y.X, x);
            }
    
            [Test]
            public void SetYToNull()
            {
                var refs = new References();
    
                var x = new X(refs);
                var y = new Y(refs);
    
    
                x.Y = y;
                y.X = null;
    
                Assert.IsNull(x.Y);
                Assert.IsNull(y.X);
            }
        }
    
        public class References
        {
            private IDictionary<X, Y> refs = new Dictionary<X, Y>();
    
            public bool Contains(X x, Y y)
            {
                if (!refs.ContainsKey(x)) return false;
                if (refs[x] != y) return false;
    
                return true;
            }
    
            public void Delete(X x)
            {
                refs.Remove(x);
            }
    
            public void Add(X x, Y y)
            {
                refs.Add(x, y);
            }
    
            public Y Get(X x)
            {
                return refs.ContainsKey(x) ? refs[x] : null;
            }
    
            public X Get(Y y)
            {
                var pairs = refs.Where(r => r.Value == y);
    
                return pairs.Any() ? pairs.FirstOrDefault().Key : null;
            }
    
            public void Delete(Y y)
            {
                X x = Get(y);
    
                if (x != null)
                {
                    Delete(x);
                }
            }
        }
    
        public class X
        {
            private readonly References refs;
    
            public X(References refs)
            {
                this.refs = refs;
            }
    
            public Y Y
            {
                get { return refs.Get(this); }
                set
                {
                    if (value == null)
                    {
                        refs.Delete(this);
                    }
                    else
                    {
                        if (!refs.Contains(this, value))
                        {
                            refs.Add(this, value);
                        }
                    }
                }
            }
        }
    
        public class Y
        {
            private References refs;
    
            public Y(References refs)
            {
                this.refs = refs;
            }
    
            public X X
            {
                get { return refs.Get(this); }
                set
                {
                    if (value == null)
                    {
                        refs.Delete(this);
                    }
                    else
                    {
                        if (!refs.Contains(value, this))
                        {
                            refs.Add(value, this);
                        }
                    }
                }
            }
        }
