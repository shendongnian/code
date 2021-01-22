    public static string SolveStrings(string Board)
    {
        string[] leafNodesOfMoves = new string[] { Board };
        while ((leafNodesOfMoves.Length > 0) && (leafNodesOfMoves[0].IndexOf(' ') != -1))
        {
            leafNodesOfMoves = (
                from partialSolution in leafNodesOfMoves
                let index = partialSolution.IndexOf(' ')
                let column = index % 9
                let groupOf3 = index - (index % 27) + column - (index % 3)
                from searchLetter in "123456789"
                let InvalidPositions =
                from spaceToCheck in Enumerable.Range(0, 9)
                let IsInRow = partialSolution[index - column + spaceToCheck] == searchLetter
                let IsInColumn = partialSolution[column + (spaceToCheck * 9)] == searchLetter
                let IsInGroupBoxOf3x3 = partialSolution[groupOf3 + (spaceToCheck % 3) +
                    (int)Math.Floor(spaceToCheck / 3f) * 9] == searchLetter
                where IsInRow || IsInColumn || IsInGroupBoxOf3x3
                select spaceToCheck
                where InvalidPositions.Count() == 0
                select partialSolution.Substring(0, index) + searchLetter + partialSolution.Substring(index + 1)
                    ).ToArray();
        }
        return (leafNodesOfMoves.Length == 0)
            ? "No solution"
            : leafNodesOfMoves[0];
    }
