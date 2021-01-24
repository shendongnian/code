    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;
    
    public class GeneratePrefab : EditorWindow
    {
    	private string prefabName = "";
    	private string objectsToSearch = "";
    	private static GeneratePrefab editor;
    	private static int width = 350;
    	private static int height = 200;
    	private static int x = 0;
    	private static int y = 0;
    	private Vector2 scroll;
    	private int count = 0;
    	private List<GameObject> foundObjects = new List<GameObject>();
    	private bool usePrefabName = false;
    	private bool searched = false;
    
    	[MenuItem("Window/Generate Prefab")]
    	static void ShowEditor()
    	{
    		editor = EditorWindow.GetWindow<GeneratePrefab>();
    
    		CenterWindow();
    	}
    
    	private void OnGUI()
    	{
    		GUI.Label(new Rect(10, 10, 80, 20), "Prefab Name");
    
    		if (usePrefabName)
    		{
    			GUI.enabled = true;
    		}
    		else
    		{
    			GUI.enabled = false;
    		}
    		prefabName = GUI.TextField(new Rect(10, 30, 150, 20), prefabName, 25);
    
    		GUI.enabled = true;
    		GUILayout.Space(55);
    		usePrefabName = GUILayout.Toggle(usePrefabName, "Use prefab name");
    
    		GUI.Label(new Rect(10, 90, 150, 20), "Search by name");
    		objectsToSearch = GUI.TextField(new Rect(10, 110, 150, 20), objectsToSearch, 25);
    
    		if (objectsToSearch != "")
    		{
    			GUI.enabled = true;
    		}
    		else
    		{
    			GUI.enabled = false;
    		}
    		GUILayout.Space(90);
    		if (GUILayout.Button("Search"))
    		{
    			count = 0;
    			foreach (GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
    			{
    				if (gameObj.name == objectsToSearch)
    				{
    					count += 1;
    					foundObjects.Add(gameObj);
    				}
    			}
    
    			if (foundObjects.Count > 0)
    			{
    				searched = true;
    			}
    			else
    			{
    				searched = false;
    			}
    		}
    
    		GUI.enabled = true;
    		if (count > 0)
    			GUI.TextField(new Rect(10, 130, 60, 20), count.ToString(), 25);
    
    		if (searched)
    		{
    			GUI.enabled = true;
    		}
    		else
    		{
    			GUI.enabled = false;
    		}
    		GUILayout.Space(0.1f);
    		if (GUILayout.Button("Generate Prefab"))
    		{
    			GameObject go = new GameObject();
    			for (int i = 0; i < foundObjects.Count; i++)
    			{
    				foundObjects[i].transform.parent = go.transform;
    			}
    
    			if (usePrefabName == true)
    				go.name = prefabName;
    
    			PrefabUtility.CreatePrefab("Assets/" + go.name + ".prefab", go);
    			DestroyImmediate(go);
    
    			objectsToSearch = "";
    			searched = false;
    			count = 0;
    		}
    	}
    
    	private static void CenterWindow()
    	{
    		editor = EditorWindow.GetWindow<GeneratePrefab>();
    		x = (Screen.currentResolution.width - width) / 2;
    		y = (Screen.currentResolution.height - height) / 2;
    		editor.position = new Rect(x, y, width, height);
    		editor.maxSize = new Vector2(width, height);
    		editor.minSize = editor.maxSize;
    	}
    }
