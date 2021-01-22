	// Getting FILL icon set from EXE, and extracting 256x256 version for logo...
	using (TKageyu.Utils.IconExtractor IconEx = new TKageyu.Utils.IconExtractor(Application.ExecutablePath))
	{
		Icon icoAppIcon = IconEx.GetIcon(0); // Because standard System.Drawing.Icon.ExtractAssociatedIcon() returns ONLY 32x32.
		picboxAppLogo.Image = ExtractVistaIcon(icoAppIcon);
	}
