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
    
      BezierCurve prevBack; // Useful later.
      BezierCurve prevFront;
    
      void OnSceneGUI()
      {
        curve = target as BezierCurve;
        if (curve == null) return;
        handleTransform = curve.transform;
        handleRotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;
    
        Vector3 p0 = ShowControlPoint(0, 1); // Pass the handle point together (for desired behavior 2.)
        Vector3 p1 = ShowHandlePoint(1);
        Vector3 p2 = ShowHandlePoint(2);
        Vector3 p3 = ShowControlPoint(3, 2);
    
        Handles.color = Color.gray;
        Handles.DrawLine(p0, p1);
        Handles.DrawLine(p2, p3);
        Handles.DrawBezier(p0, p3, p1, p2, Color.white, null, 2f);
    
        // Handles multiple selection
        var sel = Selection.GetFiltered(typeof(BezierCurve), SelectionMode.Deep | SelectionMode.Editable);
        if (sel.Length == 1)
        {
          // This snippet checks if you just attached or dettached another curve,
          // so it updates the attached member in the other curve too automatically
          if (prevBack != curve.attachBack)
          {
            if (prevBack != null) { prevBack.attachFront = null; }
            prevBack = curve.attachBack;
          }
          if (prevFront != curve.attachFront)
          {
            if (prevFront != null) { prevFront.attachBack = null; }
            prevFront = curve.attachFront;
          }
        }
    
        // Constraints for a curve attached to back
        // The trick here is making the object being inspected the "master" and the attached object is adjusted to it.
        // This way, you avoid the conflict of one object trying to move the other.
        // [ExecuteInEditMode] on component class makes it posible to have real-time drawing while editing.
        // If you were calling DrawBezierCurve from here, you would only see updates on the other curve when you select it
        if (curve.attachBack != null & curve.attachBack != curve)
        {
          // Join the attached points.
          var thisPoint = curve.transform.TransformPoint(curve.points[0]);
          var attach = curve.attachBack;
          attach.points[3] = attach.transform.InverseTransformPoint(thisPoint);
          curve.attachBack.attachFront = curve;
          attach.smoothFront = curve.smoothBack;
          if (curve.smoothBack)
          {
            // If you set smooth to True, constraint the tangents
            var attachedPoint = curve.transform.TransformPoint(curve.points[1]);
            var diff = attachedPoint - thisPoint;
            attach.points[2] = attach.transform.InverseTransformPoint(thisPoint - diff);
          }
        }
        // Same for the other end
        if (curve.attachFront != null & curve.attachBack != curve)
        {
          var thisPoint = curve.transform.TransformPoint(curve.points[3]);
          var attach = curve.attachFront;
          attach.points[0] = attach.transform.InverseTransformPoint(thisPoint);
          curve.attachFront.attachBack = curve;
          attach.smoothBack = curve.smoothFront;
          if (curve.smoothFront)
          {
            thisPoint = curve.transform.TransformPoint(curve.points[3]);
            var attachedPoint = curve.transform.TransformPoint(curve.points[2]);
            var diff = attachedPoint - thisPoint;
            attach.points[1] = attach.transform.InverseTransformPoint(thisPoint - diff);
          }
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
    
      // Pass the tangent point too, so they move together (desired behavior 2.)
      Vector3 ShowControlPoint(int index, int handleIndex)
      {
        Vector3 point = handleTransform.TransformPoint(curve.points[index]);
        EditorGUI.BeginChangeCheck();
        point = Handles.DoPositionHandle(point, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
          Undo.RecordObject(curve, "Move Control Point");
          var localDispl = handleTransform.InverseTransformPoint(point) - curve.points[index];
          curve.points[index] = handleTransform.InverseTransformPoint(point);
          curve.points[handleIndex] += localDispl;
        }
        return point;
      }
    
      Vector3 ShowHandlePoint(int index)
      {
        Vector3 point = handleTransform.TransformPoint(curve.points[index]);
        EditorGUI.BeginChangeCheck();
        point = Handles.DoPositionHandle(point, handleRotation);
        if (EditorGUI.EndChangeCheck())
        {
          Undo.RecordObject(curve, "Move Handle Point");
          curve.points[index] = handleTransform.InverseTransformPoint(point);
        }
        return point;
      }
    }
