    using UnityEngine;
    using System.Collections.Generic;
    
    [System.Serializable]
    public class Path
    {
      [SerializeField] List<ControlPoint> _points;
    
      [SerializeField] bool _loop = false;
    
      public Path(Vector2 position)
      {
        _points = new List<ControlPoint>
        {
          new ControlPoint(position),
          new ControlPoint(position + Vector2.right)
        };
      }
    
      public bool loop { get { return _loop; } set { _loop = value; } }
    
      public ControlPoint this[int i] { get { return _points[(_loop && i == _points.Count) ? 0 : i]; } }
    
      public int NumPoints { get { return _points.Count; } }
    
      public int NumSegments { get { return _points.Count - (_loop ? 0 : 1); } }
    
      public ControlPoint InsertPoint(int i, Vector2 position, bool smooth)
      {
        _points.Insert(i, new ControlPoint(position, smooth));
        return this[i];
      }
      public ControlPoint RemovePoint(int i)
      {
        var item = this[i];
        _points.RemoveAt(i);
        return item;
      }
      public Vector2[] GetBezierPointsInSegment(int i)
      {
        var pointBack = this[i];
        var pointFront = this[i + 1];
        return new Vector2[4]
        {
          pointBack.position,
          pointBack.position + pointBack.tangentFront,
          pointFront.position + pointFront.tangentBack,
          pointFront.position
        };
      }
    
      public ControlPoint MovePoint(int i, Vector2 position)
      {
        this[i].position = position;
        return this[i];
      }
    
      public ControlPoint MoveTangentBack(int i, Vector2 position)
      {
        this[i].tangentBack = position;
        return this[i];
      }
    
      public ControlPoint MoveTangentFront(int i, Vector2 position)
      {
        this[i].tangentFront = position;
        return this[i];
      }
    }
