    for (int i = 0; i < tzPlayInfo.Instance.bc_gametablelist.Count; i++)
    {
        dealer_image += tzPlayInfo.Instance.bc_gametablelist[i].dlrimage;
        Debug.Log("HERE ARE THE LINKS : " + dealer_image);
        new BestHTTP.HTTPRequest(new System.Uri("***********.amazonaws.com/resources" + "/dealer/pic/" + dealer_image),
            (BestHTTP.HTTPRequest req, BestHTTP.HTTPResponse res) =>
            {
                tex.LoadImage(res.Data);
                uitex[i].GetComponent<UITexture>().mainTexture = tex;
            }).Send();
    }
