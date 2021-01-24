    using System;
    using UnityEditor;
    using UnityEngine;
    
    public class TestArrayOfArray : MonoBehaviour
    {
    	[Serializable]
    	public struct ComboItem
    	{
    		public string value;
    	}
    
    	[Serializable]
    	public struct Combo
    	{
    		public ComboItem[] items;
    	}
    
    	public Combo[] combos;
    }
    
    [CustomPropertyDrawer(typeof(TestArrayOfArray.ComboItem))]
    public class ComboItemDrawer : PropertyDrawer
    {
    	static readonly string[] comboItemDatabase = { "Bla", "Bli", "Blu" };
    	static readonly GUIContent[] comboItemDatabaseGUIContents = Array.ConvertAll(comboItemDatabase, i => new GUIContent(i));
    
    	public override void OnGUI( Rect position, SerializedProperty property, GUIContent label )
    	{
    		property = property.FindPropertyRelative("value");
    
    		EditorGUI.BeginChangeCheck();
    		int selectedIndex = Array.IndexOf(comboItemDatabase, property.stringValue);
    		selectedIndex = EditorGUI.Popup(position, label, selectedIndex, comboItemDatabaseGUIContents);
    		if (EditorGUI.EndChangeCheck())
    		{
    			property.stringValue = comboItemDatabase[selectedIndex];
    		}
    	}
    }
