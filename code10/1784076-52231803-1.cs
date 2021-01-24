    private static void MakeSpawner(string[] types, int x, int y, int z)
    {
        if (types.Length == 0)
            return;
        ClearSpawners(x, y, z);
        Spawner sp = new Spawner(types);
        sp.Count = ICount;
        sp.HomeRange = HomeRange;
        sp.MoveToWorld(new Point3D(x, y, z), Map.Sample);
        if (TotalRespawn)
        {
            sp.Respawn();
            sp.BringToHome();
        }
        ++m_Count;
    }
