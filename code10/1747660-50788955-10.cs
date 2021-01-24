    using System;
    using UnityEngine;
    
    [Serializable]
    public class ControlPoint
    {
      [SerializeField] Vector2 _position;
      [SerializeField] bool _smooth;
      [SerializeField] Vector2 _tangentBack;
      [SerializeField] Vector2 _tangentFront;
    
      public Vector2 position
      {
        get { return _position; }
        set { _position = value; }
      }
    
      public bool smooth
      {
        get { return _smooth; }
        set { if (_smooth = value) _tangentBack = -_tangentFront; }
      }
    
      public Vector2 tangentBack
      {
        get { return _tangentBack; }
        set
        {
          _tangentBack = value;
          if (_smooth) _tangentFront = _tangentFront.magnitude * -value.normalized;
        }
      }
    
      public Vector2 tangentFront
      {
        get { return _tangentFront; }
        set
        {
          _tangentFront = value;
          if (_smooth) _tangentBack = _tangentBack.magnitude * -value.normalized;
        }
      }
    
      public ControlPoint(Vector2 position, bool smooth = true)
      {
        this._position = position;
        this._smooth = smooth;
        this._tangentBack = -Vector2.one;
        this._tangentFront = Vector2.one;
      }
    }
