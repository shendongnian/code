    using UnityEngine;
    
    public enum BlockColors {blank, red, blue, green, yellow, cyan, white, purple};
    
    [System.Serializable] public class level {
    	#if UNITY_EDITOR
    	[HideInInspector] public bool showBoard;
    	#endif
    	public int rows = 9;
    	public int column = 9;
    	public BlockColors [,] board = new BlockColors [columns, rows];
	}
	
	
	public class Levels : MonoBehaviour {
		public Level[] allLevels;
	}
