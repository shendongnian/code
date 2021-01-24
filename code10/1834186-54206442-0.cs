    public static void SaveColor (Color color, string key) {
		PlayerPrefs.SetFloat(key + "R", color.r);
		PlayerPrefs.SetFloat(key + "G", color.g);
		PlayerPrefs.SetFloat(key + "B", color.b);
	}
	public static Color GetColor (string key) {
		float R = PlayerPrefs.GetFloat(key + "R");
		float G = PlayerPrefs.GetFloat(key + "G");
		float B = PlayerPrefs.GetFloat(key + "B");
		return new Color(R, G, B);
	}
