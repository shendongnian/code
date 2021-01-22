    // winnable positions
    var winnables = new[] {
        "012",
        "345",
        "678",
        "036",
        "147",
        "258",
        "048",
        "246"
    };
    // extracted from btnOne Two Three....
    var gameState = new[] { "X", "O", "X", "whatever" };
    string winner = null;
    // check each winnable positions
    foreach (var position in winnables) {
        var pos1 = int.Parse(position[0].ToString());
        var pos2 = int.Parse(position[1].ToString());
        var pos3 = int.Parse(position[2].ToString());
        if (gameState[pos1] == gameState[pos2] &&
            gameState[pos2] == gameState[pos3])
            winner = gameState[pos1];
    }
    // do we have a winner?
    if (!string.IsNullOrEmpty(winner))
        /* we've got a winner */
