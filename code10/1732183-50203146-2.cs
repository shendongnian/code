    static string BuildCustomEditorCode (string name)
    {
      return @"using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;
    [CustomEditor(typeof(" + name + @"))]
    public class " + name + @"Editor : Editor {
    public override void OnInspectorGUI ()
    {
      base.OnInspectorGUI ();
      var obj = (" + name + @") target;
      if (GUILayout.Button (""Hi!"")) {
        // do something with obj when button is clicked
        Debug.Log(""Button pressed for: "" + obj.name);
        EditorGUIUtility.PingObject (obj);
      }
    }
    }";
    }
