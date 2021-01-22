	using Microsoft.Xna.Framework;
	using System;
	namespace DL
	{
		[Serializable()]
		public class CameraProperty
		{
			#region [READONLY PROPERTIES]
			public static readonly string CameraPropertyVersion = "v1.00";
			#endregion [READONLY PROPERTIES]
			
			/// <summary>
			/// CONSTRUCTOR
			/// </summary>
			public CameraProperty() {
				// INIT
                Scrolling               = 0f;
				CameraPos               = new Vector2(0f, 0f);
			}
			#region [PROPERTIES]   
			/// <summary>
			/// Scrolling
			/// </summary>
			public float Scrolling { get; set; }
			/// <summary>
			/// Position of the camera
			/// </summary>
			public Vector2 CameraPos;
            // instead of: public Vector2 CameraPos { get; set; }
	  
			#endregion [PROPERTIES]
		}
	}      
