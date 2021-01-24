    //---------------------
    //FrankGames production
    //---------------------
    
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEditor;
    
    public class GetStatsWindow : EditorWindow {
    
    	private static Material m_DefaultMat = null;
    	private static int m_c = -1;
    	private static int m_c2 = 0;
    
    	private static bool m_DisplayResult = false;
    	private static Vector2 m_RectPos = Vector2.zero;
    
    	private static GameObject[] m_ObjsFound = new GameObject[0];
    
    	private static bool m_Working = false;
    
    	//-----------------------------------------------------------------------------
    	// ShowWindow
    	//-----------------------------------------------------------------------------
    	[MenuItem ("Window/Find Objects with Material")]
    	public static void ShowWindow () {
    		EditorWindow.GetWindow (typeof (GetStatsWindow));
    	}
    
    	//-----------------------------------------------------------------------------
    	// OnGUI
    	//-----------------------------------------------------------------------------
    	void OnGUI () {
    		EditorGUILayout.BeginVertical ();
    
    		EditorGUILayout.HelpBox ("First, select a material in the 'Material to find' Input field.\nThan press the 'Find' Button.\nAfter some calculations (it could take some time, depending on your Hardware and the amount of objects and Materials that it has to check.", MessageType.Info);
    
    		if (m_Working)
    			EditorGUI.BeginDisabledGroup (true);
    		
    		m_DefaultMat = EditorGUILayout.ObjectField ("Material to find", m_DefaultMat, typeof (Material), true) as Material;
    
    		if (m_DefaultMat == null && !m_Working)
    			EditorGUI.BeginDisabledGroup (true);
    
    		if (GUILayout.Button ("Find Objects")) {
    			getObjWithMat ();
    		}
    
    		if (m_DefaultMat == null && !m_Working)
    			EditorGUI.EndDisabledGroup ();
    
    		if (m_Working)
    			EditorGUILayout.LabelField ("Calculating...");
    
    		if (m_c != -1) {
    			if (GUILayout.Button ("Clear result") && EditorUtility.DisplayDialog ("Are you sure?", "Do you really want to clear the result of your search?", "Continue", "Cancel")) {
    				m_DefaultMat = null;
    				m_c = -1;
    				m_c2 = 0;
    				m_DisplayResult = false;
    				m_RectPos = Vector2.zero;
    				m_ObjsFound = new GameObject[0];
    				m_Working = false;
    			} else {
    
    				EditorGUILayout.LabelField (m_c2 + " Objects have been checked!");
    				EditorGUILayout.LabelField (m_c + " Objects with the '" + m_DefaultMat.name + "' Material have been found!");
    
    				m_DisplayResult = EditorGUILayout.Toggle ("Display Results", m_DisplayResult);
    
    				if (m_DisplayResult) {
    					EditorGUILayout.LabelField ("Objects found with '" + m_DefaultMat.name + "':");
    
    					m_RectPos = EditorGUILayout.BeginScrollView (m_RectPos);
    					EditorGUILayout.BeginVertical ();
    					EditorGUI.BeginDisabledGroup (true);
    					for (int i = 0; i < m_ObjsFound.Length; i++) {
    						EditorGUILayout.ObjectField ("[" + i + "] Object found", m_ObjsFound [i], typeof(GameObject), true);
    					}
    					EditorGUI.EndDisabledGroup ();
    					EditorGUILayout.EndVertical ();
    					EditorGUILayout.EndScrollView ();
    
    				}
    			}
    		}
    		
    		if (m_Working)
    			EditorGUI.EndDisabledGroup ();
    		
    		EditorGUILayout.EndVertical ();
    	}
    
    	//-----------------------------------------------------------------------------
    	// getObjWithMat
    	//-----------------------------------------------------------------------------
    	public static int getObjWithMat (Material mat = null) {
    		if (mat != null)
    			m_DefaultMat = mat;
    		else if (m_DefaultMat == null)
    			return -1;
    		
    		m_Working = true;
    
    		m_c = 0;
    		m_c2 = 0;
    
    		List<GameObject> Objs = new List<GameObject> ();
    
    		GameObject[] AllObjs = Object.FindObjectsOfType<GameObject> ();
    		foreach (GameObject Obj in AllObjs) {
    			m_c2++;
    			bool Found = false;
    			if (Obj.activeInHierarchy) {
    				if (Obj.GetComponent <Renderer> ()) {
    					foreach (Material Mat in Obj.GetComponent <Renderer> ().sharedMaterials) {
    						if (Mat == m_DefaultMat) {
    							Found = true;
    							m_c++;
    						}
    					}
    				}
    			}
    			if (Found)
    				Objs.Add (Obj);
    		}
    
    		m_ObjsFound = Objs.ToArray ();
    		Objs.Clear ();
    
    		m_Working = false;
    
    		return m_c;
    	}
    
    }
