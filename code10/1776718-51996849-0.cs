        [System.Web.Http.HttpGet]
        [System.Web.Http.ActionName("GetPrint")]
        //[ResponseType(typeof(HttpResponseMessage))]
        public HttpResponseMessage GetPrint(string templateName, int personId, int badgeId, string authToken, string ipAddress)
        {
            var bdgBl = PeliquinIOC.Instance.Resolve<IBadgeDesignBL>(UserId, UserName, PropertyCode, PartitionName, IpAddress);
            //if (!(IsAllowed(SysPrivConstants.SYSPRIV__TYPE_PERSONNEL, templateName, SysPrivConstants.SYSPRIV__LEVEL_READ)))
            //{
            //    return (Unauthorized());
            //}
            var bdgDto = bdgBl.GetPrint(templateName, personId, badgeId);
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(bdgDto)
            };
            result.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = $"badge_{badgeId}.pdf"
                };
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");
            return result;
        }
