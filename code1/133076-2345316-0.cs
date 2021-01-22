    using System.Collections.Generic;
    using AtomPhysics.Interfaces;
    
    namespace AtomPhysics.Collisions
    {
        public class SweepAndPruneBroadPhase : IBroadPhaseCollider
        {
            private INarrowPhaseCollider _narrowPhase;
            private AtomPhysicsSim _sim;
            private List<Extent> _xAxisExtents = new List<Extent>();
            private List<Extent> _yAxisExtents = new List<Extent>();
            private Extent e1;
    
            public SweepAndPruneBroadPhase(INarrowPhaseCollider narrowPhase)
            {
                _narrowPhase = narrowPhase;
            }
    
            public AtomPhysicsSim Sim
            {
                get { return _sim; }
                set { _sim = null; }
            }
            public INarrowPhaseCollider NarrowPhase
            {
                get { return _narrowPhase; }
                set { _narrowPhase = value; }
            }
            public bool NeedsNotification { get { return true; } }
    
    
            public void Add(Nucleus nucleus)
            {
                Extent xStartExtent = new Extent(nucleus, ExtentType.Start);
                Extent xEndExtent = new Extent(nucleus, ExtentType.End);
                _xAxisExtents.Add(xStartExtent);
                _xAxisExtents.Add(xEndExtent);
                Extent yStartExtent = new Extent(nucleus, ExtentType.Start);
                Extent yEndExtent = new Extent(nucleus, ExtentType.End);
                _yAxisExtents.Add(yStartExtent);
                _yAxisExtents.Add(yEndExtent);
            }
            public void Remove(Nucleus nucleus)
            {
                foreach (Extent e in _xAxisExtents)
                {
                    if (e.Nucleus == nucleus)
                    {
                        _xAxisExtents.Remove(e);
                    }
                }
                foreach (Extent e in _yAxisExtents)
                {
                    if (e.Nucleus == nucleus)
                    {
                        _yAxisExtents.Remove(e);
                    }
                }
            }
    
            public void Update()
            {
                _xAxisExtents.InsertionSort(comparisonMethodX);
                _yAxisExtents.InsertionSort(comparisonMethodY);
                for (int i = 0; i < _xAxisExtents.Count; i++)
                {
                    e1 = _xAxisExtents[i];
                    if (e1.Type == ExtentType.Start)
                    {
                        HashSet<Extent> potentialCollisionsX = new HashSet<Extent>();
                        for (int j = i + 1; j < _xAxisExtents.Count && _xAxisExtents[j].Nucleus.ID != e1.Nucleus.ID; j++)
                        {
                            potentialCollisionsX.Add(_xAxisExtents[j]);
                        }
                        HashSet<Extent> potentialCollisionsY = new HashSet<Extent>();
                        for (int j = i + 1; j < _yAxisExtents.Count && _yAxisExtents[j].Nucleus.ID != e1.Nucleus.ID; j++)
                        {
                            potentialCollisionsY.Add(_yAxisExtents[j]);
                        }
    
                        List<Extent> probableCollisions = new List<Extent>();
                        foreach (Extent e in potentialCollisionsX)
                        {
                            if (potentialCollisionsY.Contains(e) && !probableCollisions.Contains(e) && e.Nucleus.ID != e1.Nucleus.ID)
                            {
                                probableCollisions.Add(e);
                            }
                        }
                        foreach (Extent e2 in probableCollisions)
                        {
                            if (e1.Nucleus.DNCList.Contains(e2.Nucleus) || e2.Nucleus.DNCList.Contains(e1.Nucleus))
                                continue;
                            NarrowPhase.DoCollision(e1.Nucleus, e2.Nucleus);
                        }
                    }
                }
            }
    
            private bool comparisonMethodX(Extent e1, Extent e2)
            {
                float e1PositionX = e1.Nucleus.NonLinearSpace != null ? e1.Nucleus.NonLinearPosition.X : e1.Nucleus.Position.X;
                float e2PositionX = e2.Nucleus.NonLinearSpace != null ? e2.Nucleus.NonLinearPosition.X : e2.Nucleus.Position.X;
                e1PositionX += (e1.Type == ExtentType.Start) ? -e1.Nucleus.Radius : e1.Nucleus.Radius;
                e2PositionX += (e2.Type == ExtentType.Start) ? -e2.Nucleus.Radius : e2.Nucleus.Radius;
                return e1PositionX < e2PositionX;
            }
            private bool comparisonMethodY(Extent e1, Extent e2)
            {
                float e1PositionY = e1.Nucleus.NonLinearSpace != null ? e1.Nucleus.NonLinearPosition.Y : e1.Nucleus.Position.Y;
                float e2PositionY = e2.Nucleus.NonLinearSpace != null ? e2.Nucleus.NonLinearPosition.Y : e2.Nucleus.Position.Y;
                e1PositionY += (e1.Type == ExtentType.Start) ? -e1.Nucleus.Radius : e1.Nucleus.Radius;
                e2PositionY += (e2.Type == ExtentType.Start) ? -e2.Nucleus.Radius : e2.Nucleus.Radius;
                return e1PositionY < e2PositionY;
            }
            private enum ExtentType { Start, End }
            private sealed class Extent
            {
                private ExtentType _type;
                public ExtentType Type
                {
                    get
                    {
                        return _type;
                    }
                    set
                    {
                        _type = value;
                        _hashcode = 23;
                        _hashcode *= 17 + Nucleus.GetHashCode();
                    }
                }
                private Nucleus _nucleus;
                public Nucleus Nucleus
                {
                    get
                    {
                        return _nucleus;
                    }
                    set
                    {
                        _nucleus = value;
                        _hashcode = 23;
                        _hashcode *= 17 + Nucleus.GetHashCode();
                    }
                }
    
                private int _hashcode;
    
                public Extent(Nucleus nucleus, ExtentType type)
                {
                    Nucleus = nucleus;
                    Type = type;
                    _hashcode = 23;
                    _hashcode *= 17 + Nucleus.GetHashCode();
                }
    
                public override bool Equals(object obj)
                {
                    return Equals(obj as Extent);
                }
                public bool Equals(Extent extent)
                {
                    if (this.Nucleus == extent.Nucleus)
                    {
                        return true;
                    }
                    return false;
                }
                public override int GetHashCode()
                {
                    return _hashcode;
                }
            }
        }
    }
