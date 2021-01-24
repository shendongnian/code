    private void ResetDataPatient() {
        imgBox.Image.Dispose();
        imgBox.Image = Properties.Resources.defaultpicture;
        if (xrayPic != null)
        {
            xrayPic.Dispose();
            xrayPic = null;
        }
        if (rootPic != null)
        {
            rootPic.Dispose();
            rootPic = null;
        }
        if (tmppic != null)
        {
            tmppic.Dispose();
            tmppic = null;
        }
        if (tmppicCheck != null)
        {
            tmppicCheck.Dispose();
            tmppicCheck = null;
        }
        if (originalPic != null)
        {
            originalPic.Dispose();
            originalPic = null;
        }
        if (PatienData != null) {
            PatienData.Clear();
            PatienData.Dispose();
            PatienData = null;
        }
    }
