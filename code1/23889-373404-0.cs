    class CommandArgs 
    {
        private Double _Position_x = null;
        private Double _Position_y = null;
        private String _Position_units = null;
        private Double _Width = null;
        private String _Width_units = null;
        private Double _Height = null;
        private String _Height_units = null;
        // maybe there's a better tuple-like type for this.
        public double[] Position 
        {
             set
             {
                 if (value.length != 2) throw new ArgumentException("argh!");
                 _Position_x = value[0];
                 _Position_y = value[1];
             }
        }
        public string Position_Units
        {
             set
             {
                 _Position_Units = value;
             }
        }
        public double Width
             set
             {
                 _Width = value;
             }
        }
        public double Height
             set
             {
                 _Height = value;
             }
        }
        public string Width_Units
             set
             {
                 _Width = value;
             }
        }
        public string Height_Units
             set
             {
                 _Height = value;
             }
        }
        // ....
        public override string ToString()
        {
             return 
                 ( _Position_x != null ? string.Format(" Position ({0},{1})",_Position_x, _Position_y ) : "" )
                 + ( _Height != null ? string.Format(" Height {0}")
                       + ( _Height_Units != null ? string.Format(" Units {0}", _Height_Units) : "" )
                 + ( _Width != null ? string.Format(" Width {0}")
                       + ( _Width_Units != null ? string.Format(" Units {0}", _Width_Units) : "" )
             // ...
             ;
        }
    }
