    using UnityEngine;
    using UnityEditor;
    
    // This attribute allows you to select multiple curves and manipulate them all as a whole on Scene or Inspector
    [CustomEditor(typeof(BezierCurve)), CanEditMultipleObjects]
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
    
      // Constraints for a curve attached to back
      // The trick here is making the object being inspected the "master" and the attached object is adjusted to it.
      // This way, you avoid the conflict of one object trying to move the other.
      // [ExecuteInEditMode] on component class makes it posible to have real-time drawing while editing.
      // If you were calling DrawBezierCurve from here, you would only see updates on the other curve when you select it
      Vector3 ShowPoint(int index)
      {
        var thisPts = curve.points;
        Vector3 point = handleTransform.TransformPoint(thisPts[index]);
        EditorGUI.BeginChangeCheck();
        point = Handles.DoPositionHandle(point, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
          if (curve.paired != null && curve.paired != curve)
          {
            Undo.RecordObjects(new Object[] { curve, curve.paired }, "Move Point " + index.ToString());
            var pairPts = curve.paired.points;
            var pairTransform = curve.paired.transform;
            switch (index)
            {
              case 0:
                {
                  if (curve.behavior1)
                  {
                    pairPts[0] = pairTransform.InverseTransformPoint(point);
                  }
                  break;
                }
              case 1:
                {
                  if (curve.behavior2)
                  {
                    var p1 = handleTransform.TransformPoint(thisPts[1]);
                    pairPts[1] += pairTransform.InverseTransformVector(point - p1);
                  }
                  break;
                }
              case 2:
                {
                  if (curve.behavior3)
                  {
                    var p0 = handleTransform.TransformPoint(thisPts[0]);
                    var p3 = handleTransform.TransformPoint(thisPts[3]);
                    var reflect = Vector3.Reflect(p3 - point, (p3 - p0).normalized);
                    pairPts[2] = pairTransform.InverseTransformPoint(p3 + reflect);
                  }
                  break;
                }
              default:
                break;
            }
          }
          else
          {
            Undo.RecordObject(curve, "Move Point " + index.ToString());
          }
          thisPts[index] = handleTransform.InverseTransformPoint(point);
        }
        return point;
      }
    }
