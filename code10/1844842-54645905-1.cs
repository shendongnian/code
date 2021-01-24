        public class AreaInfo : Common
        {
          public int AreaId { get; set; }        
          public string AreaName { get; set; }
        }
        public class Area : AreaInfo
        {
          public string PinCode{ get; set; }
        }
//...
          public IHttpActionResult GetAreaById(int AreaId, int LoginId)
          {
            try
            {
                AreaDAL objDal = new AreaDAL();
                Area objBo = new Area();
                objBo = objDal.EditArea(AreaId, LoginId);
    
                if (objBo != null)
                {
                   return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, new AreaInfo { AreaId = objBo.AreaId, AreaName = objBo.AreaName }));
    
                   return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, objBo));    
               }
           }
