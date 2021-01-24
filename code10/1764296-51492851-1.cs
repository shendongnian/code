    //Acquire the IVsImageService2in the Package
    var imageService = (IVsImageService2)Package.GetGlobalService(typeof(SVsImageService));
    //Using the IVsImageService2 the query icons.
    public Icon GetIcon(IClosedDocument document)
	{
		IVsUIObject uIObj = _vsImageService2.GetIconForFile(document.Name, __VSUIDATAFORMAT.VSDF_WINFORMS);
		Icon icon = (Icon)GelUtilities.GetObjectData(uIObj);
		return icon;
	}
