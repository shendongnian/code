    using UnityEngine;
    using UnityEditor;
    
    [CustomEditor(typeof(PathCreator))]
    public class PathCreatorEditor : Editor
    {
      PathCreator creator;
      Path path;
      SerializedProperty property;
    
      public override void OnInspectorGUI()
      {
        serializedObject.Update();
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(property, true);
        if (EditorGUI.EndChangeCheck()) serializedObject.ApplyModifiedProperties();
      }
    
      void OnSceneGUI()
      {
        Input();
        Draw();
      }
    
      void Input()
      {
        Event guiEvent = Event.current;
        Vector2 mousePos = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition).origin;
        mousePos = creator.transform.InverseTransformPoint(mousePos);
        if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.shift)
        {
          Undo.RecordObject(creator, "Insert point");
          path.InsertPoint(path.NumPoints, mousePos, false);
        }
        else if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0 && guiEvent.control)
        {
          for (int i = 0; i < path.NumPoints; i++)
          {
            if (Vector2.Distance(mousePos, path[i].position) <= .25f)
            {
              Undo.RecordObject(creator, "Remove point");
              path.RemovePoint(i);
              break;
            }
          }
        }
      }
    
      void Draw()
      {
        Handles.matrix = creator.transform.localToWorldMatrix;
        var rot = Tools.pivotRotation == PivotRotation.Local ? creator.transform.rotation : Quaternion.identity;
        var snap = Vector2.zero;
        Handles.CapFunction cap = Handles.CylinderHandleCap;
        for (int i = 0; i < path.NumPoints; i++)
        {
          var pos = path[i].position;
          var size = .1f;
          Handles.color = Color.red;
          Vector2 newPos = Handles.FreeMoveHandle(pos, rot, size, snap, cap);
          if (pos != newPos)
          {
            Undo.RecordObject(creator, "Move point position");
            path.MovePoint(i, newPos);
          }
          pos = newPos;
          if (path.loop || i != 0)
          {
            var tanBack = pos + path[i].tangentBack;
            Handles.color = Color.black;
            Handles.DrawLine(pos, tanBack);
            Handles.color = Color.red;
            Vector2 newTanBack = Handles.FreeMoveHandle(tanBack, rot, size, snap, cap);
            if (tanBack != newTanBack)
            {
              Undo.RecordObject(creator, "Move point tangent");
              path.MoveTangentBack(i, newTanBack - pos);
            }
          }
          if (path.loop || i != path.NumPoints - 1)
          {
            var tanFront = pos + path[i].tangentFront;
            Handles.color = Color.black;
            Handles.DrawLine(pos, tanFront);
            Handles.color = Color.red;
            Vector2 newTanFront = Handles.FreeMoveHandle(tanFront, rot, size, snap, cap);
            if (tanFront != newTanFront)
            {
              Undo.RecordObject(creator, "Move point tangent");
              path.MoveTangentFront(i, newTanFront - pos);
            }
          }
        }
      }
    
      [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
      static void DrawGizmo(PathCreator creator, GizmoType gizmoType)
      {
        Handles.matrix = creator.transform.localToWorldMatrix;
        var path = creator.path;
        for (int i = 0; i < path.NumSegments; i++)
        {
          Vector2[] points = path.GetBezierPointsInSegment(i);
          Handles.DrawBezier(points[0], points[3], points[1], points[2], Color.green, null, 2);
        }
      }
    
      void OnEnable()
      {
        creator = (PathCreator)target;
        path = creator.path ?? creator.CreatePath();
        property = serializedObject.FindProperty("path");
      }
    }
