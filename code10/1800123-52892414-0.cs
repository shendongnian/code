    using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	public class Test07a : MonoBehaviour {
		public Color normalColor;
		public Color selectedColor;
		public Image image;
		private bool isSelected;
		public void Select(){
			isSelected = !isSelected;
			image.color = isSelected ? selectedColor : normalColor;
			if (isSelected) {
				Debug.Log ("selected");
			} else {
				Debug.Log ("not selected");
			}
		}
	}
