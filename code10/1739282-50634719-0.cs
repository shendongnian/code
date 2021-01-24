    using UnityEngine;
    
    [RequireComponent(typeof(LineRenderer))]
    [ExecuteInEditMode]
    public class BezierCurve : MonoBehaviour
    {
    
      public Vector3[] points;
      public int numPoints = 51;
      public BezierCurve attachBack;
      public bool smoothBack;
      public BezierCurve attachFront;
      public bool smoothFront;
      LineRenderer lr;
    
      void Reset()
      {
        points = new Vector3[]
        {
          new Vector3(1f, 0f, 0f),
          new Vector3(2f, 0f, 0f),
          new Vector3(3f, 0f, 0f),
          new Vector3(4f, 0f, 0f)
        };
      }
    
      void Start()
      {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = numPoints;
      }
    
      void Update()
      {
        DrawBezierCurve();
      }
    
      void OnValidate()
      {
        if (attachBack == this) attachBack = null;
        if (attachFront == this) attachFront = null;
      }
    
      void DrawBezierCurve()
      {
        for (int i = 0; i < numPoints; i++)
        {
          float t = i / (float)(numPoints - 1);
          lr.SetPosition(i, GetPoint(t));
        }
      }
    
      public Vector3 GetPoint(float t)
      {
        return transform.TransformPoint(Bezier.GetPoint(points[0], points[1], points[2], points[3], t));
      }
    
      public Vector3 GetVelocity(float t)
      {
        return transform.TransformPoint(Bezier.GetFirstDerivative(points[0], points[1], points[2], points[3], t)) - transform.position;
      }
    
      public Vector3 GetDirection(float t)
      {
        return GetVelocity(t).normalized;
      }
    }
