    public class Board : MonoBehaviour
    {
        List<Piece> pieces = new List<Piece>();
    
        void Start()
        {
            // Initialize the collection of pieces 
            transform.GetComponentsInChildren(pieces);               
        }
        public string GetFEN() 
        {
            foreach (Piece piece in pieces)
            {
                char fen = piece.GetFEN();
     
                // TODO: Do what you need with the character
            }
        }
    }
