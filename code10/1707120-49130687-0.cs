    public enum PlayerPosition {
        North,
        Top, 
        South,
        Bottom,
        East,
        Right,
        West,
        Left
    }
    
    switch (obj.PlayerPosition)
    {
        case PlayerPosition.Top:
        case PlayerPosition.North:
            // some code
            break;
        case PlayerPosition.Bottom:
        case PlayerPosition.South:
            // some code
            break;
        case PlayerPosition.Right:
        case PlayerPosition.East:
            // some code
            break;
        case PlayerPosition.Left:
        case PlayerPosition.West:
            // some code
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
