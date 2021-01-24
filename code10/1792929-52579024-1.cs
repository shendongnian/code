	private void OnGUI()
	{
		// on OnGUI start
		if (firstEnterAfterFocus)
		{
			RemoveInputFocus();
			firstEnterAfterFocus = false;
		}
	}
	private bool firstEnterAfterFocus;
	private void OnFocus()
	{
		firstEnterAfterFocus = true;
		// RemoveInputFocus();
	}
	private static void RemoveInputFocus()
	{
		// EditorGUI.FocusTextInControl(null);
		GUIUtility.keyboardControl = 0;
	}
