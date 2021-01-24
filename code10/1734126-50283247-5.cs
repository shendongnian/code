    protected override List<Rect> InternalRun()
    {
       for (var index = 0; index < Input.Cubes.Count; index++)
       {
          Input.Cubes[index] = Input.ByReturn(Input.Cubes[index]);
       }
    
       return Input.Cubes.ToList();
    }
