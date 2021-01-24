    public GameObject [] dress;
        
        private int _index;
        public void PreviousModel()
        {
            _index = Mathf.Clamp(_index-1,0,9);
            // code to show your model dress[_index] ...
        
        }
        
        public void NextModel()
        {
            _index = Mathf.Clamp(_index+1,0,9);
            // code to show your model dress[_index] ...
        
        }
