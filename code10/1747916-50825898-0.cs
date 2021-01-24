    using UnityEditor;
    using UnityEngine;
    using System.Collections.Generic;
    
    namespace PersistChangesThroughAssemblyLoad
    {
    	public class MyEditorWindow : EditorWindow
    	{
    		Vector2 buttonStartPosition = new Vector2(0, 0);
    		Vector2 buttonStartSize = new Vector2(100f, 40f);
    		int yOffset = 10;
    
    		// All data types which should be peristent, need to be
    		// serializable, Vector2 is, but Rect is not.
    		List<Vector2> buttonPositions = new List<Vector2>();
    		List<Vector2> buttonSizes = new List<Vector2>();
    
    		[MenuItem("Window/MyEditorWindow")]
    		static void Init()
    		{
    			MyEditorWindow window = GetWindow<MyEditorWindow>("MyWindow");
    			LogMessage(window, "Window will be opened via the menu item.");
    			window.Show();
    		}
    
    		void OnEnable()
    		{
    			LogMessage("Window is enabled (either after opening or after assembly reload/recompile).");
    		}
    
    		void OnDisable()
    		{
    			LogMessage("Window is disabled (either when being closed or because the assembly is about to reload/recompile).");
    		}
    
    		void OnGUI()
    		{
    			if (GUILayout.Button("Add Button"))
    			{
    				buttonStartPosition.y += buttonStartSize.y + yOffset;
    				AddNewButton(buttonStartPosition, buttonStartSize);
    			}
    
    			for (int i = 0; i < buttonPositions.Count; i++)
    			{
    				string buttonName = "Button " + i;
    				if (GUI.Button(new Rect(buttonPositions[i], buttonSizes[i]), buttonName))
    				{
    					LogMessage(buttonName + " was clicked!");
    				}
    			}
    		}
    
    		void AddNewButton(Vector2 position, Vector2 size)
    		{
    			buttonPositions.Add(position);
    			buttonSizes.Add(size);
    			LogMessage("Added new button. Total count: " + buttonPositions.Count);
    		}
    
    		void LogMessage(string message)
    		{
    			LogMessage(this, message);
    		}
    
    		static void LogMessage(Object context, string message)
    		{
    			Debug.Log("Window [" + context.GetInstanceID() + "]: " + message);
    		}
    	}
    }
