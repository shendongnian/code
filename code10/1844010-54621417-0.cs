    using UnityEngine;
    
    /// <summary> The base class for all the chess pieces to inherit from. </summary>
    public abstract class Piece : MonoBehaviour
    {    
        [SerializeField] protected bool black; // set in the inspector for each piece
        public abstract char Letter { get; }
    
        /// <summary> Returns the chess FEN notation character representing the piece. </summary>
        public char GetFEN() => (black) ? char.ToLowerInvariant(Letter) : char.ToUpperInvariant(Letter);   
    } 
