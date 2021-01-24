    public static IEnumerable<Vector2Int> AsEnumerable()
    {
        for (var i = 0; i < 4; i++)
        {
            switch (i)
            {
                case 1:
                    yield return North;
                    break;
                case 2:
                    yield return South;
                    break;
                case 3:
                    yield return East;
                    break;
                case 4:
                    yield return West;
                    break;
            }
        }
    }
