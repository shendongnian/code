    const int CF_BITMAP = 2;
	System.Runtime.InteropServices.ComTypes.FORMATETC formatEtc;
	System.Runtime.InteropServices.ComTypes.STGMEDIUM stgMedium;
    formatEtc = new System.Runtime.InteropServices.ComTypes.FORMATETC();
    formatEtc.cfFormat = CF_BITMAP;
    formatEtc.dwAspect = System.Runtime.InteropServices.ComTypes.DVASPECT.DVASPECT_CONTENT;
    formatEtc.lindex = -1;
    formatEtc.tymed = System.Runtime.InteropServices.ComTypes.TYMED.TYMED_GDI;
