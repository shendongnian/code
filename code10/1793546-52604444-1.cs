      class Room
      {
        private Double dblLength;
        private Double dblWidth;
        public bool HasError {get;}
        public Room (Double _dblLength, Double _dblWidth)
        {
          if (_dblLength < _dblWidth)
          {
              HasError = true;
          }
          dblLength = _dblLength;
          dblWidth = _dblWidth;
        }
        public Save()
        {
            if (HasError) return;
            // Otherwise do the save;
        }
    }
