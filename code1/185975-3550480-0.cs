    public class Vols
    { 
        private List<double> _vols = new List<double>();
    
        public void AddVolume( double volume )
        {
            _vols.Add( volume );
        }
        public void GetVolume( int index )
        {
            return _vols.ElementAtOrDefault( index );
        }
    }
    
