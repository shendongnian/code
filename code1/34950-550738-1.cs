        public abstract class PointList<T> : IPointList where T : IPoint
        {
            public IList<T> GetPoints
            {
                get
                {
                    return GetPointsCore ();
                }
            }
            
            IList<IPoint> IPointList.GetPoints
            {
                get
                {
                    return GetPointsCore () as IList<IPoint>;
                }        
            }
    
            protected abstract IList<T> GetPointsCore();        
        }
