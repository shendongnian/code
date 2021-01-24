    for (int i = 0; i < tzPlayInfo.Instance.bc_gametablelist.Count; i++)
        {
            dealer_img += tzPlayInfo.Instance.bc_gametablelist[i].dlrimage;
            dealer_img += ",";
        }
        string[] newLinks = dealer_img.Split(',');
        for (int i = 0; i < newLinks.Length - 1; i++)
        {
            var index = i;  // We need to make a local copy because C# captures variables by reference to lambdas.
            new BestHTTP.HTTPRequest(new System.Uri("***************.amazonaws.com/resources/"
                + "dealer/pic/" + newLinks[index]),
                (BestHTTP.HTTPRequest req, BestHTTP.HTTPResponse res)
                =>
                {
                    var tex = new Texture2D(20, 20);
                    tex.LoadImage(res.Data);
                    uitex[index].GetComponent<UITexture>().mainTexture = tex;
                }).Send();
        }
