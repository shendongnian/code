    public enum PlayerColor {
        Red = 0, Green, Blue, Cyan, Yellow, Orange, Purple, Magenta
    }
    public PlayerColor GetNextFreeColor(PlayerColor oldColor) {
        PlayerColor newColor = (PlayerColor)((int)(oldColor + 1) % 8);
        return newColor;
    }
