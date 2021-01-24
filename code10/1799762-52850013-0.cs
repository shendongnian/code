    public class SelectedEntitiesEqualityComparer : IEqualityComparer<SelectedEntities>
    {
        public bool Equals( SelectedEntities x, SelectedEntities y )
        {
            if( object.ReferenceEquals( x, y ) )
                return true;
            if( x == null || y == null )
                return false;
            return x.Id.Equals( y.Id ) && 
                   x.IsDelegator.Equals(y.IsDelegator) &&
                   x.IsDelegate.Equals(y.IsDelegate);
        }
        public int GetHashCode( SelectedEntities obj )
        {
            return obj.Id.GetHashCode( )^
                   obj.IsDelegator.GetHashCode()^
                   obj.IsDelegate.GetHashCode();
        }
    }
