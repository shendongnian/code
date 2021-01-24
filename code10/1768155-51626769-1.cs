     [HttpPost]
        public HttpResponseMessage InsertNodeAssets(int NodeID, string AssetID)
        {
            var AssetArray = AssetID.Split(',');
            try
            {
                foreach (var item in AssetArray)
                {
                    using (DTO.IOTAModel context = new DTO.IOTAModel())
                    {
                        DTO.NodeAssets lvNodeAsset = new DTO.NodeAssets();
                        lvNodeAsset.AssetId = Convert.ToInt32(item);
                        lvNodeAsset.NodeId = NodeID;
                        lvNodeAsset.LastUpdateDate = DateTime.Now;
                        context.NodeAssets.Add(lvNodeAsset);
                        context.SaveChanges();
                    }
                }
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                log.Error("", ex);
                return this.Request.CreateResponse(HttpStatusCode.ExpectationFailed);
            }
        }
    }
