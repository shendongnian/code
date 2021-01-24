    protected override List<Rect> InternalRun()
    {
       for (var index = 0; index < Input.Cubes.Count; index++)
       {
          var t = Input.Cubes[index];
          Input.ByRef(ref t);
          Input.Cubes[index] = t;
       }
    
       return Input.Cubes.ToList();
    }
