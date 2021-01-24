        //polyCollider
        polyCollider.pathCount = 1;
        List<Vector2> pathList = new List<Vector2> { };
        for (int i = 0; i < n; i++)
        {
            pathList.Add(new Vector2(verticies[i].x, verticies[i].y));
        }
        Vector2[] path = pathList.ToArray();
        polyCollider.SetPath(0, path);
