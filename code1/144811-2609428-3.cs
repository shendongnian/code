    var controls = new FormControl[]
    {
        new FormControl(ddlTranscriptionMethod),
        new FormControl(ddlSpeechRecognition),
        new DependentFormControl(SliderControl1, () => !SliderControl1.SliderDisable),
        new FormControl(ddlESignature),
        new DependentFormControl(chkViaFax, () => tblDistributionMethods.Visible),
        new DependentFormControl(chkViaInterface, () => tblDistributionMethods.Visible),
        new DependentFormControl(chkViaPrint, () => tblDistributionMethods.Visible),
        new DependentFormControl(chkViaSelfService, () => tblDistributionMethods.Visible)
    };
    controls.FocusFirst();
