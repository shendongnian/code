    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEditor;
    using System.IO;
    public class Explorer : MonoBehaviour 
    {
	string path;
	public MeshRenderer mRenderer;
	public void OpenExplorer()
	{
			path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
			GetImage();
	}
	void GetImage()
	{
		if (path != null)
		{
			UpdateImage();
		}
	}
		void UpdateImage()
	{
		byte[] imgByte = File.ReadAllBytes(path);
		Texture2D texture = new Texture2D (2, 2);
		texture.LoadImage(imgByte);
		mRenderer.material.mainTexture = texture;
		//WWW www = new WWW("file:///" + path);
		//yield return www;
		//image.texture = texture;
	    }
    }
