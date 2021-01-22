    public interface IGame<T> where T:IMove
        {
            void PerformMove(T move);
        }
    
    public class TTTGame : IGame<TTTMove>
        {
    
            public void PerformMove(TTTMove move)
            {
                //perform move
            }
    
        }
