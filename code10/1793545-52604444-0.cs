    class Room
      {
      private Double dblLength;
      private Double dblWidth;
      public Room (Double _dblLength, Double _dblWidth)
      {
        if (_dblLength < _dblWidth)
        {
            throw new ArgumentException("length must be more than width");
        }
        dblLength = _dblLength;
        dblWidth = _dblWidth;
      }
    }
