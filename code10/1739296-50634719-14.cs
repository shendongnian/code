    using UnityEngine;
    
    [RequireComponent(typeof(LineRenderer))]
    [ExecuteInEditMode] // Makes Update() being called often even in Edit Mode
    public class BezierCurve : MonoBehaviour
    {
    
      public Vector3[] points;
      public int numPoints = 50;
      // Curve that is paired with this curve
      public BezierCurve paired;
      public bool behavior1; // check on editor if you desired behavior 1 ON/OFF
      public bool behavior2; // check on editor if you desired behavior 2 ON/OFF
      public bool behavior3; // check on editor if you desired behavior 3 ON/OFF
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
      }
    
      void Update()
      {
        // This component is the only responsible for drawing itself.
        DrawBezierCurve();
      }
    
      // This method is called whenever a field is changed on Editor
      void OnValidate()
      {
        // This avoids pairing with itself
        if (paired == this) paired = null;
      }
    
      void DrawBezierCurve()
      {
        lr.positionCount = numPoints;
        for (int i = 0; i < numPoints; i++)
        {
          // This corrects the "strange" extra point you had with your script.
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
