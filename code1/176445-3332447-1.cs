    Class Tetris{
        Public Color GetColorAt(int x, int y){
            return  _engine.GetColorAt(x,y);
        }
    }
    Class Boardengine{
        Public Color GetColorAt(int x, int y){
            return  _board.GetColorAt(x,y);
        }
    }
  
