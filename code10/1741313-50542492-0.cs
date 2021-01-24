    public void ValidateWebCams() {
        if (Webcams == null || Webcams.Length == 0) {
                throw new System.Exception("Webcams not populated!");
        }
        List<Webcam> newWebCamList = new List<Webcam>();
        foreach (Webcam cam in this.Webcams) {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(cam.Currentimageurl);
            try {
                HttpWebResponse response = (HttpWebResponse)(request.GetResponse());
                newWebCamList.Add(cam);
            }
            catch (WebException ex) {
                var response = (HttpWebResponse)ex.Response; //in case I want to examine this
            }//end catch                  
        }//end foreach
        this.Webcams = new Webcam[newWebCamList.Count];
        int loopCounter = 0;
        foreach (Webcam cam in newWebCamList) {
            this.Webcams[loopCounter++] = cam;
        }
    }
