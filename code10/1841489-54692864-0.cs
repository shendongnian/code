    using System;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEditorInternal;
    using UnityEngine;
    
    [Serializable]
    public class SomeClass
    {
        public string Name;
        public List<SomeClass> InnerList;
    }
    
    [CreateAssetMenu(menuName = "Example", fileName = "new Example Asset")]
    public class Example : ScriptableObject
    {
        public List<SomeClass> SomeClasses;
    
        [CustomEditor(typeof(Example))]
        private class ModuleDrawer : Editor
        {
            private SerializedProperty SomeClasses;
            private ReorderableList list;
    
            private Dictionary<string, ReorderableList> innerListDict = new Dictionary<string, ReorderableList>();
    
            private void OnEnable()
            {
                SomeClasses = serializedObject.FindProperty("SomeClasses");
    
                // setupt the outer list
                list = new ReorderableList(serializedObject, SomeClasses)
                {
                    displayAdd = true,
                    displayRemove = true,
                    draggable = true,
    
                    drawHeaderCallback = rect =>
                    {
                        EditorGUI.LabelField(rect, "Outer List");
                    },
    
                    drawElementCallback = (rect, index, a, h) =>
                    {
                        // get outer element
                        var element = SomeClasses.GetArrayElementAtIndex(index);
    
                        var InnerList = element.FindPropertyRelative("InnerList");
    
                        string listKey = element.propertyPath;
    
                        ReorderableList innerReorderableList;
    
                        if (innerListDict.ContainsKey(listKey))
                        {
                            // fetch the reorderable list in dict
                            innerReorderableList = innerListDict[listKey];
                        }
                        else
                        {
                            // create reorderabl list and store it in dict
                            innerReorderableList = new ReorderableList(element.serializedObject, InnerList)
                            {
                                displayAdd = true,
                                displayRemove = true,
                                draggable = true,
    
                                drawHeaderCallback = innerRect =>
                                {
                                    EditorGUI.LabelField(innerRect, "Inner List");
                                },
    
                                drawElementCallback = (innerRect, innerIndex, innerA, innerH) =>
                                {
                                    // Get element of inner list
                                    var innerElement = InnerList.GetArrayElementAtIndex(innerIndex);
    
                                    var name = innerElement.FindPropertyRelative("Name");
    
                                    EditorGUI.PropertyField(innerRect, name);
                                }
                            };
                            innerListDict[listKey] = innerReorderableList;
                        }
    
                        // Setup the inner list
                        var height = (InnerList.arraySize + 3) * EditorGUIUtility.singleLineHeight;
                        innerReorderableList.DoList(new Rect(rect.x, rect.y, rect.width, height));
                    },
    
                    elementHeightCallback = index =>
                    {
                        var element = SomeClasses.GetArrayElementAtIndex(index);
    
                        var innerList = element.FindPropertyRelative("InnerList");
    
                        return (innerList.arraySize + 4) * EditorGUIUtility.singleLineHeight;
                    }
                };
            }
    
            public override void OnInspectorGUI()
            {
                serializedObject.Update();
    
                list.DoLayoutList();
    
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
