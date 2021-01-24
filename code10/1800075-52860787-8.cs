    // Script name : MyCustomListEditor.cs
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
     
    [CustomEditor(typeof(MyCustomList))]
     
    public class MyCustomListEditor : Editor {
        MyCustomList t;
        SerializedObject GetTarget;
        SerializedProperty ThisList;
        int ListSize;
     
        void OnEnable(){
            t = (MyCustomList)target;
            GetTarget = new SerializedObject(t);
            ThisList = GetTarget.FindProperty("MyList"); // Find the List in our script and create a reference of it
        }
     
        public override void OnInspectorGUI(){
            //Update our list
       
            GetTarget.Update();
       
            //Resize our list
            EditorGUILayout.Space ();
            EditorGUILayout.Space ();
            ListSize = ThisList.arraySize;
            ListSize = EditorGUILayout.IntField ("List Size", ListSize);
       
            if(ListSize != ThisList.arraySize){
                while(ListSize > ThisList.arraySize){
                    ThisList.InsertArrayElementAtIndex(ThisList.arraySize);
                }
                while(ListSize < ThisList.arraySize){
                    ThisList.DeleteArrayElementAtIndex(ThisList.arraySize - 1);
                }
            }
       
            EditorGUILayout.Space ();
            EditorGUILayout.Space ();
       
            //Display our list to the inspector window
     
            for(int i = 0; i < ThisList.arraySize; i++){
                SerializedProperty MyListRef = ThisList.GetArrayElementAtIndex(i);
                SerializedProperty MyEnum= MyListRef.FindPropertyRelative("enumName");
                SerializedProperty MyName = MyListRef.FindPropertyRelative("name");
                SerializedProperty MyStep = MyListRef.FindPropertyRelative("step");
                SerializedProperty MyPosition = MyListRef.FindPropertyRelative("position");
     
         
                EditorGUILayout.PropertyField(MyEnum);
    
                int MyEnumIndex = MyEnum.enumValueIndex;
                // Show/hide the properties based on the index of the enumValue. 
                if (MyEnumIndex == (int)MyListItem.MyEnumType.first) {
                    EditorGUILayout.PropertyField(MyName);
                } 
                if (MyEnumIndex == (int)MyListItem.MyEnumType.second) {
                    EditorGUILayout.PropertyField(MyPosition);
                }
                EditorGUILayout.PropertyField(MyStep);
                
                EditorGUILayout.Space ();
           
                //Remove this index from the List
                if(GUILayout.Button("Remove This Index (" + i.ToString() + ")")){
                    ThisList.DeleteArrayElementAtIndex(i);
                }
                EditorGUILayout.Space ();
                EditorGUILayout.Space ();
                EditorGUILayout.Space ();
                EditorGUILayout.Space ();
            }
       
            //Apply the changes to our list
            GetTarget.ApplyModifiedProperties();
        }
    }
