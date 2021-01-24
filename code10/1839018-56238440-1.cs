    [...]
    case (AcroFields.FIELD_TYPE_CHECKBOX):
                        
     PdfDictionary ap = item.getWidget(i).getAsDict(PdfName.AP);
     if (ap != null) {
        PdfDictionary normalAp = ap.getAsDict(PdfName.N);
        changeAppearanceStateNames(normalAp, "NewExportValue", "Check Box106");
        
        PdfDictionary downAp = ap.getAsDict(PdfName.D);
        changeAppearanceStateNames(downAp, "NewExportValue", "Check Box106"););
        
        PdfDictionary rolloverAp = ap.getAsDict(PdfName.R);
        changeAppearanceStateNames(rolloverAp, "NewExportValue", "Check Box106");
     }
    break; [...]
    private void changeAppearanceStateNames(PdfDictionary appearanceSubdictionary, String newValue, String fieldname) throws NotSpecCompliantException {
	    if (appearanceSubdictionary != null) {
            if(appearanceSubdictionary.size()>2) throw Exception ...
            
            String appearanceSubDictionaryName=null;
            
			//detect name for the checked value
            for(Object key : appearanceSubdictionary.getKeys()) {
                String name = PdfName.decodeName(((PdfName)key).toString());
                
                if(!name.equals("Off")) {
                    appearanceSubDictionaryName=name;
                }
            }
			
			//update it
            if(appearanceSubDictionaryName!=null) {
                PdfObject appearanceSubDictionaryValue = appearanceSubdictionary.get(new PdfName(appearanceSubDictionaryName));
                appearanceSubdictionary.remove(new PdfName(appearanceSubDictionaryName));
                appearanceSubdictionary.put(new PdfName(newValue),appearanceSubDictionaryValue);
            }
            //else {
				//theoretically create a new appearance here. Details can be seen in the #RadioCheckField
                //however since only the export value should be changed it is assumed that the actual appearance dictionary does already exists
            //}
        }
	}
