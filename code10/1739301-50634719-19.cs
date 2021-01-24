    using UnityEngine;
    using UnityEditor;
    
    [CustomEditor(typeof(BezierCurve))]
    // This attribute allows you to select multiple curves and manipulate them all as a whole on Scene or Inspector
    [CanEditMultipleObjects]
    public class BezierCurveEditor : Editor
    {
      BezierCurve curve;
      Transform handleTransform;
      Quaternion handleRotation;
      const int lineSteps = 10;
      const float directionScale = 0.5f;
    
      BezierCurve prevPartner; // Useful later.
    
      void OnSceneGUI()
      {
        curve = target as BezierCurve;
        if (curve == null) return;
        handleTransform = curve.transform;
        handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;
    
        Vector3 p0 = ShowPoint(0);
        Vector3 p1 = ShowPoint(1);
        Vector3 p2 = ShowPoint(2);
        Vector3 p3 = ShowPoint(3);
    
        Handles.color = Color.gray;
        Handles.DrawLine(p0, p1);
        Handles.DrawLine(p2, p3);
        Handles.DrawBezier(p0, p3, p1, p2, Color.white, null, 2f);
    
        // Handles multiple selection
        var sel = Selection.GetFiltered(typeof(BezierCurve), SelectionMode.Editable);
        if (sel.Length == 1)
        {
          // This snippet checks if you just attached or dettached another curve,
          // so it updates the attached member in the other curve too automatically
          if (prevPartner != curve.paired)
          {
            if (prevPartner != null) { prevPartner.paired = null; }
            prevPartner = curve.paired;
          }
        }
    
        if (curve.paired != null & curve.paired != curve)
        {
          // Pair the curves.
          var partner = curve.paired;
          partner.paired = curve;
          partner.behavior1 = curve.behavior1;
          partner.behavior2 = curve.behavior2;
          partner.behavior3 = curve.behavior3;
        }
      }
    
      void ShowDirections()
      {
        Handles.color = Color.green;
        Vector3 point = curve.GetPoint(0f);
        Handles.DrawLine(point, point + curve.GetDirection(0f) * directionScale);
        for (int i = 1; i <= lineSteps; i++)
        {
          point = curve.GetPoint(i / (float)lineSteps);
          Handles.DrawLine(point, point + curve.GetDirection(i / (float)lineSteps) * directionScale);
        }
      }
    
      // Constraints for a curve attached to back
      // The trick here is making the object being inspected the "master" and the attached object is adjusted to it.
      // This way, you avoid the conflict of one object trying to move the other.
      // [ExecuteInEditMode] on component class makes it posible to have real-time drawing while editing.
      // If you were calling DrawBezierCurve from here, you would only see updates on the other curve when you select it
      Vector3 ShowPoint(int index)
      {
        Vector3 point = handleTransform.TransformPoint(curve.points[index]);
        EditorGUI.BeginChangeCheck();
        point = Handles.DoPositionHandle(point, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
          Undo.RecordObject(curve, "Move Point" + index.ToString());
          var thisPts = curve.points;
          var pairPts = curve.paired.points;
          switch (index)
          {
            case 0:
              {
                if (curve.behavior1)
                {
                  pairPts[0] = curve.paired.transform.InverseTransformPoint(point);
                }
                break;
              }
            case 1:
              {
                if (curve.behavior2)
                {
                  pairPts[1] -= thisPts[1] - handleTransform.InverseTransformPoint(point);
                }
                break;
              }
            case 2:
              {
                if (curve.behavior3)
                {
                  pairPts[2] = thisPts[3] + Vector3.Reflect(thisPts[3] - thisPts[2], (thisPts[0] - thisPts[3]).normalized);
                }
                break;
              }
            default:
              break;
          }
          curve.points[index] = handleTransform.InverseTransformPoint(point);
        }
        return point;
      }
    }
