    case FileUploadControl.UploaderType.DocumentTemplate:
        (this.Page as PageBase).SetMessage(string.Format(GetLocalResourceObject("FileExtensionError").ToString(), docIndentifier, formatAllowed(ucdocxUploadControl.SupportedFileTypes)), PageMessageType.ErrorMessage);
        break;
    case FileUploadControl.UploaderType.MModalTemplate:
        (this.Page as PageBase).SetMessage(string.Format(GetLocalResourceObject("FileExtensionError").ToString(), docIndentifier, formatAllowed(ucampUploadControl.SupportedFileTypes)), PageMessageType.ErrorMessage);
        (this.Page as PageBase).SetMessage(string.Format(GetLocalResourceObject("FileExtensionErrorForBoth").ToString(), formatAllowed(ucdocxUploadControl.SupportedFileTypes), formatAllowed(ucampUploadControl.SupportedFileTypes)), PageMessageType.ErrorMessage);
        break;
    case FileUploadControl.UploaderType.DocumentTemplate:
        (this.Page as PageBase).SetMessage(string.Format(GetLocalResourceObject("FileExtensionErrorForBoth").ToString(), formatAllowed(ucdocxUploadControl.SupportedFileTypes), formatAllowed(ucampUploadControl.SupportedFileTypes)), PageMessageType.ErrorMessage);
        break;
