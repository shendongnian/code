    protected override List<Rect> InternalRun()
    {
       return Input.Cubes = Input.Cubes.Select(r => Input.ByReturn(r))
                                 .ToList();
    }
